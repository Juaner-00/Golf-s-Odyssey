using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    [SerializeField]
    string nextLevelName;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
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

    public void Quit()
    {
        Application.Quit();
    }

}
