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

    [HideInInspector]
    public Grid grid;

    public void Start()
    {
        if (grid == null)
        {
            grid = new Grid(width, height, cellSize, originPosition);
            Debug.Log("Create grid");
        }
    }

    public void ResetGrid()
    {
        grid = new Grid(width, height, cellSize, originPosition);
        Debug.Log("New grid");
    }

    private void Update()
    {
        HandleClickToModifyGrid();

        if (Input.GetMouseButtonDown(1))
            Debug.Log(grid.GetState(UtilsClass.GetMouseWorldPosition()));
    }

    private void HandleClickToModifyGrid()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetState(UtilsClass.GetMouseWorldPosition(), true);
        }
    }

}
