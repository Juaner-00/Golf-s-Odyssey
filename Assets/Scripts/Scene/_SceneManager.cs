using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    [SerializeField]
    string levelName;
    [SerializeField]
    string level1Name = "Tutorial Level_01";

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Pinicio");
    }
    public void MapMenu()
    {
        SceneManager.LoadScene("MapLvls");
    }


    public void LoadMainM()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        
    }

}
