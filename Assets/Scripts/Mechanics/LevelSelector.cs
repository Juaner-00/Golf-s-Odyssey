using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [ Expandable] public  LevelsObject levelsObject;

    public static Island lastIsland;

    public static LevelSelector Instance { get; private set; }



    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }
}
