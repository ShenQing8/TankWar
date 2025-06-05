using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPanel : BasePanel<DefeatPanel>
{
    public ButtonPre BackBtn;
    public ButtonPre AgainBtn;

    private void Start()
    {
        BackBtn.ClickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        };
        AgainBtn.ClickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        };

        HideMe();
    }
}
