using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    [SerializeField]
    string nextLevelName;

    public static _SceneManager Instance { get; private set; }

    private List<AsyncOperation> levelsLoading = new List<AsyncOperation>();

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    public void LoadNextLevel()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync(nextLevelName/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void Reset()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadMainMenu()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Pinicio"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void MapMenu()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("MapLvls"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private IEnumerator GetSceneLoadProgress()
    {
        foreach (var scene in levelsLoading)
            while (!scene.isDone)
                yield return null;

        MenuManager.Instance.CloseLoading();
        levelsLoading.Clear();
    }

    public void LoadLvl1()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_01"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl2()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_02"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl3()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_03"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl4()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_04"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl5()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_05"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl6()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_06"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl7()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_07"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl8()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_08"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }
    public void LoadLvl9()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("Tutorial Level_09"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());

    }

}
