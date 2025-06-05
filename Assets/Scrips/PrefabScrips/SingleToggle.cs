using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToggle : MonoBehaviour
{
    // 把单选框当作一个多选框管理器

    public MultiToggles[] toggles;
    MultiToggles FrontToggle;

    private void Start()
    {
        if (toggles.Length == 0)
            return;
        // 为每个多选框添加委托，当一个为true时，其他都变为false
        for (int i = 0; i < toggles.Length; ++i)
        {
            MultiToggles toggle = toggles[i];
            toggle.IsOn = false;
            toggle.IstrueToDoEvent += (value) =>
            {
                if (value)
                {
                    for (int j = 0; j < toggles.Length; ++j)
                    {
                        if (toggle != toggles[j])
                            toggles[j].IsOn = false;
                    }
                    FrontToggle = toggle;
                }
                else if (FrontToggle == toggle)
                {
                    // 强制改为true
                    toggle.IsOn = true;
                }
            };
        }
        // 默认第一个选项为true
        toggles[0].IsOn = true;
    }


}

