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

    public void LoadSystem1()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("System1"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadSystem2()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("System2"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadSystem3()
    {
        MenuManager.Instance.OpenLoading();
        levelsLoading.Add(SceneManager.LoadSceneAsync("System3"/* , LoadSceneMode.Additive */));
        levelsLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadNextLevel()
    {

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
        levelsLoading.Add(SceneManager.LoadSceneAsync("MainMenu"/* , LoadSceneMode.Additive */));
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

}
