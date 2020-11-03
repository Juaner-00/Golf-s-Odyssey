using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField, Expandable] LevelsObject levelsObject;

    public static SaveAndLoad Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void Save(int level, int val)
    {
        switch (level)
        {
            case 1:
                PlayerPrefs.SetInt("lvl1", val);
                break;
            case 2:
                PlayerPrefs.SetInt("lvl2", val);
                break;
            case 3:
                PlayerPrefs.SetInt("lvl3", val);
                break;
            case 4:
                PlayerPrefs.SetInt("lvl4", val);
                break;
            case 5:
                PlayerPrefs.SetInt("lvl5", val);
                break;
            case 6:
                PlayerPrefs.SetInt("lvl6", val);
                break;
            case 7:
                PlayerPrefs.SetInt("lvl7", val);
                break;
            case 8:
                PlayerPrefs.SetInt("lvl8", val);
                break;
            case 9:
                PlayerPrefs.SetInt("lvl9", val);
                break;
            case 10:
                PlayerPrefs.SetInt("lvl10", val);
                break;
        }
    }

    public void Load()
    {
        levelsObject.starsLevel1 = PlayerPrefs.GetInt("lvl1", 0);
        levelsObject.starsLevel2 = PlayerPrefs.GetInt("lvl2", 0);
        levelsObject.starsLevel3 = PlayerPrefs.GetInt("lvl3", 0);
        levelsObject.starsLevel4 = PlayerPrefs.GetInt("lvl4", 0);
        levelsObject.starsLevel5 = PlayerPrefs.GetInt("lvl5", 0);
        levelsObject.starsLevel6 = PlayerPrefs.GetInt("lvl6", 0);
        levelsObject.starsLevel7 = PlayerPrefs.GetInt("lvl7", 0);
        levelsObject.starsLevel8 = PlayerPrefs.GetInt("lvl8", 0);
        levelsObject.starsLevel9 = PlayerPrefs.GetInt("lvl9", 0);
        levelsObject.starsLevel10 = PlayerPrefs.GetInt("lvl10", 0);
    }

    public static void Clear()
    {
        PlayerPrefs.SetInt("lvl1", 0);
        PlayerPrefs.SetInt("lvl2", 0);
        PlayerPrefs.SetInt("lvl3", 0);
        PlayerPrefs.SetInt("lvl4", 0);
        PlayerPrefs.SetInt("lvl5", 0);
        PlayerPrefs.SetInt("lvl6", 0);
        PlayerPrefs.SetInt("lvl7", 0);
        PlayerPrefs.SetInt("lvl8", 0);
        PlayerPrefs.SetInt("lvl9", 0);
        PlayerPrefs.SetInt("lvl10", 0);
    }
}