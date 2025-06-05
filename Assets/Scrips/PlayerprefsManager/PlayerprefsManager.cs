using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerprefsManager
{
    #region 单例模式
    private static PlayerprefsManager instance = new PlayerprefsManager();
    private PlayerprefsManager() { }
    public static PlayerprefsManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion


    private void SavedataFunc(object value, string CustomName)
    {
        if (value == null)
            return;

        Type valtype = value.GetType();
        if (valtype == typeof(int))
        {
            PlayerPrefs.SetInt(CustomName, (int)value);
        }
        else if (valtype == typeof(float))
        {
            PlayerPrefs.SetFloat(CustomName, (float)value);
        }
        else if (valtype == typeof(string))
        {
            PlayerPrefs.SetString(CustomName, value.ToString());
        }
        else if (valtype == typeof(bool))
        {
            PlayerPrefs.SetInt(CustomName, (bool)value ? 1 : 0);
        }
        else if (valtype.IsGenericType && valtype.GetGenericTypeDefinition() == typeof(List<>))
        {
            int i = 0;
            string tmpName;
            // 唯一命名规则：CustomName + _i
            foreach (var con in (IEnumerable)value)
            {
                tmpName = CustomName + $"_{i}";
                SavedataFunc(con, tmpName);
                ++i;
            }
            // 保存List<>中的成员数量
            // 唯一命名规则：CustomName + _Count
            PlayerPrefs.SetInt(CustomName + "_Count", i);
        }
        else if (valtype.IsGenericType && valtype.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            int i = 0;
            string KeyName;
            string ValueName;

            // 唯一命名规则：CustomName + _i + _Key/Value
            foreach (DictionaryEntry entry in (IDictionary)value)
            {
                KeyName = CustomName + $"_{i}_Key";
                ValueName = CustomName + $"_{i}_Value";
                SavedataFunc(entry.Key, KeyName);
                SavedataFunc(entry.Value, ValueName);
                ++i;
            }
            // 保存Dictionary<,>中的成员数量
            // 唯一命名规则：CustomName + _Count
            PlayerPrefs.SetInt(CustomName + "_Count", i);
        }
        else if (valtype.IsClass)
        {
            // 唯一命名规则：CustomName + _类型 + _类型名
            string tmpName;
            FieldInfo[] infos = valtype.GetFields();

            for (int i = 0; i < infos.Length; ++i)
            {
                tmpName = CustomName + $"_{infos[i].FieldType.Name}_{infos[i].Name}";

                SavedataFunc(infos[i].GetValue(value), tmpName);
            }
        }
    }


    private object LoaddataFunc(Type memType, string CustomName)
    {
        if (memType == typeof(int))
        {
            return PlayerPrefs.GetInt(CustomName, 0);
        }
        else if (memType == typeof(float))
        {
            return PlayerPrefs.GetFloat(CustomName, 0);
        }
        else if (memType == typeof(string))
        {
            return PlayerPrefs.GetString(CustomName);
        }
        else if (memType == typeof(bool))
        {
            return PlayerPrefs.GetInt(CustomName) == 1;
        }
        else if (memType.IsGenericType && memType.GetGenericTypeDefinition() == typeof(List<>))
        {
            // 获取List<>中共有多少成员
            int count = PlayerPrefs.GetInt(CustomName + "_Count");
            string tmpName;
            Type genericType = memType.GetGenericArguments()[0];

            IList ret = Activator.CreateInstance(memType) as IList;

            for (int i = 0; i < count; ++i)
            {
                tmpName = CustomName + $"_{i}";

                ret.Add(LoaddataFunc(genericType, tmpName));
            }

            return ret;
        }
        else if (memType.IsGenericType && memType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            // 获取Dictionar<,>中共有多少成员
            int count = PlayerPrefs.GetInt(CustomName + "_Count");
            string KeyName;
            string ValueName;
            Type[] genericType = memType.GetGenericArguments();

            IDictionary ret = Activator.CreateInstance(memType) as IDictionary;

            for (int i = 0; i < count; ++i)
            {
                KeyName = CustomName + $"_{i}_Key";
                ValueName = CustomName + $"_{i}_Value";

                ret.Add(LoaddataFunc(genericType[0], KeyName), LoaddataFunc(genericType[1], ValueName));
            }

            return ret;
        }
        else if (memType.IsClass)
        {
            object ret = Activator.CreateInstance(memType);
            FieldInfo[] infos = memType.GetFields();

            string tmpName;

            for (int i = 0; i < infos.Length; ++i)
            {
                tmpName = CustomName + $"_{infos[i].FieldType.Name}_{infos[i].Name}";

                infos[i].SetValue(ret, LoaddataFunc(infos[i].FieldType, tmpName));
            }

            return ret;
        }

        return null;
    }

    public void SaveDate(object obj, string keyName)
    {
        // 得到obj的类型
        Type type = obj.GetType();
        // 得到类的所有字段
        FieldInfo[] infos = type.GetFields();
        // 唯一的存储名：keyName_类名_类型_类型名
        string CustomName;

        for (int i = 0; i < infos.Length; ++i)
        {
            CustomName = $"{keyName}_{type.Name}_{infos[i].FieldType.Name}_{infos[i].Name}";

            SavedataFunc(infos[i].GetValue(obj), CustomName);
        }

        // 及时保存，防止数据丢失
        PlayerPrefs.Save();
    }


    public object LoadData(Type type, string keyName)
    {
        // 实例化要读取的类型
        object ret = Activator.CreateInstance(type);
        // 得到类中所有字段
        FieldInfo[] infos = type.GetFields();

        // 用来存唯一的存储名
        string CustomName;

        for (int i = 0; i < infos.Length; ++i)
        {
            CustomName = $"{keyName}_{type.Name}_{infos[i].FieldType.Name}_{infos[i].Name}";

            infos[i].SetValue(ret, LoaddataFunc(infos[i].FieldType, CustomName));
        }

        return ret;
    }

    /// <summary>
    /// 进行泛型重载
    /// </summary>
    /// <typeparam name="T">想要加载的类型</typeparam>
    /// <param name="Name">唯一的名字</param>
    /// <returns></returns>
    public T LoadData<T>(string keyName) where T : class
    {
        return LoadData(typeof(T), keyName) as T;
    }
}
