using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelClear;
    [SerializeField] TextMeshProUGUI countStrikes;

    private static LevelClearManager instance;
    public static LevelClearManager Instance { get => instance; }

    public static event OnClearLevelManager OnClearLevel;
    public delegate void OnClearLevelManager();

    bool hasClear;
    public bool HasClear { get => hasClear; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        hasClear = false;
    }

    public void ShowLevelDialog(string status, string cStrikes)
    {
        MenuManager.Instance.OpenDialog();
        levelClear.text = status;
        countStrikes.text = cStrikes;
        hasClear = true;
        OnClearLevel?.Invoke();
    }
}
