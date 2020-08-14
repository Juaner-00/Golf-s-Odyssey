using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    int height = 10, width = 10;

    [SerializeField]
    float cellSize = 1;

    [SerializeField]
    Vector3 originPosition = new Vector3();

    public Color canPlaceColor = new Color(0, 1, 0, 0.5f), cantPlaceColor = new Color(1, 0, 0, 0.5f);


    public GridAsset gridAsset;


    public void Init()
    {
        if (gridAsset.gridCells == null)
        {
            gridAsset.gridCells = new bool[width, height];
            Debug.Log("Init");
        }
    }

    public void ReCreate()
    {
        gridAsset.gridCells = new bool[width, height];
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public bool[,] GetGridCells()
    {
        return gridAsset.gridCells;
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }

    private void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public void SetState(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < gridAsset.gridCells.GetLength(0) && z < gridAsset.gridCells.GetLength(1))
            gridAsset.gridCells[x, z] = !GetState(x, z);
    }

    public void SetState(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetState(x, z);
    }

    public bool GetState(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < gridAsset.gridCells.GetLength(0) && z < gridAsset.gridCells.GetLength(1))
            return gridAsset.gridCells[x, z];
        else
            return false;
    }

    public bool GetState(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetState(x, z);
    }

}
