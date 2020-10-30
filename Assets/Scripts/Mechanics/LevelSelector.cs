using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField, Expandable] private LevelsObject levelsObject;

    public static Island lastIsland;

    public static LevelSelector Instance { get; private set; }

    public LevelsObject LevelsObject { get; }


    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }
}
