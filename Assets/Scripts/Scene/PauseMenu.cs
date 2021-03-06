﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        MenuManager.Instance.OpenUI();
        Time.timeScale = 1;
        paused = false;
    }

    public void Pause()
    {
        MenuManager.Instance.OpenPause();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(MenuManager.Instance.time * 1.5f);
        Time.timeScale = 0;
        paused = true;
    }
}