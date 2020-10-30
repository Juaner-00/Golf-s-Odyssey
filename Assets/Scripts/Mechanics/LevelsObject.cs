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
    , starsLevel10, starsLevel11, starsLevel12;
    public int starCount
    {
        get
        {
            return starsLevel1 + starsLevel2 + starsLevel3
            + starsLevel4 + starsLevel5 + starsLevel6
            + starsLevel7 + starsLevel8 + starsLevel9
            + starsLevel10 + starsLevel11 + starsLevel12;
        }
    }
    public int[] lista
    {
        get
        {
            return new int[] {starsLevel1, starsLevel2, starsLevel3
                     , starsLevel4, starsLevel5, starsLevel6
                  , starsLevel7, starsLevel8, starsLevel9
                  , starsLevel10, starsLevel11, starsLevel12
            };
        }
        
            
        
    }
    public void AsignarEstrellas(int nivel, int cEstrellas)
    {
        switch (nivel)
        {

            case 1:
                if (cEstrellas > starsLevel1) starsLevel1 = cEstrellas;
                break;
            case 2:
                if (cEstrellas > starsLevel2) starsLevel2 = cEstrellas;
                break;
            case 3:
                if (cEstrellas > starsLevel3) starsLevel3 = cEstrellas;
                break;
            case 4:
                if (cEstrellas > starsLevel4) starsLevel4 = cEstrellas;
                break;
            case 5:
                if (cEstrellas > starsLevel5) starsLevel5 = cEstrellas;
                break;
            case 6:
                if (cEstrellas > starsLevel6) starsLevel6 = cEstrellas;
                break;
            case 7:
                if (cEstrellas > starsLevel7) starsLevel7 = cEstrellas;
                break;
            case 8:
                if (cEstrellas > starsLevel8) starsLevel8 = cEstrellas;
                break;
            case 9:
                if (cEstrellas > starsLevel9) starsLevel9 = cEstrellas;
                break;
            case 10:
                if (cEstrellas > starsLevel10) starsLevel10 = cEstrellas;
                break;
            case 11:
                if (cEstrellas > starsLevel11) starsLevel11 = cEstrellas;
                break;
            case 12:
                if (cEstrellas > starsLevel12) starsLevel12 = cEstrellas;
                break;

               
                

        }
    }
}

public enum Island
{
    None, Troya, Sirena, Ciclipe, Bruja, Itaca
}