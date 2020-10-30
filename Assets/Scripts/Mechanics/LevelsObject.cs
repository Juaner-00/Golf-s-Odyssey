using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelsObject", menuName = "LevelsObject")]
public class LevelsObject : ScriptableObject
{
    [Range(0, 3)]
    public int starsLevel1, starsLevel2, starsLevel3
    , starsLevel4, starsLevel5, starsLevel6
    , starsLevel7, starsLevel8, starsLevel9
    , starsLevel10, starsLevel11, starsLevel12
    , starsLevel13, starsLevel14, starsLevel15;
    public int starCount
    {
        get
        {
            return starsLevel1 + starsLevel2 + starsLevel3
            + starsLevel4 + starsLevel5 + starsLevel6
            + starsLevel7 + starsLevel8 + starsLevel9
            + starsLevel10 + starsLevel11 + starsLevel12
            + starsLevel13 + starsLevel14 + starsLevel15;
        }
    }
}

public enum Island
{
    None, Troya, Sirena, Ciclipe, Bruja, Itaca
}