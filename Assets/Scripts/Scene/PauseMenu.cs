using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused { get; private set; } = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true)
            	Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        MenuManager.Instance.OpenUI();
        Time.timeScale = 1;
        IsPaused = false;

    }

    public void Pause()
    {
        MenuManager.Instance.OpenPause();
        Time.timeScale = 0;
        IsPaused = true;
    }
}