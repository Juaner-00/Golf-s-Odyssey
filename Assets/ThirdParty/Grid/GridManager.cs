/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    int height = 50, width = 50;

    [SerializeField]
    float cellSize = 1;

    [SerializeField]
    Vector3 originPosition = new Vector3();

    public Color canPlaceColor = new Color(0, 1, 0, 0.5f), cantPlaceColor = new Color(1, 0, 0, 0.5f);

    public Grid grid;

    public void Init()
    {
        if (grid == null)
            ResetGrid();
    }

    public void ResetGrid()
    {
        Debug.Log("ResetGrid");
        grid = new Grid(width, height, cellSize, originPosition);
    }

    public void SetState(Vector3 position)
    {
        grid.SetState(position, !GetState(position));
    }

    public bool GetState(Vector3 position)
    {
        return grid.GetState(position);
    }

}
