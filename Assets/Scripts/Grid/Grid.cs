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


    private bool[,] gridArray;


    public void Init()
    {
        if (gridArray == null)
        {
            Debug.Log("Init");
            gridArray = new bool[width, height];
        }
    }

    public void ReCreate()
    {
        gridArray = new bool[width, height];
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

    public bool[,] GetGridArray()
    {
        return gridArray;
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
        if (x >= 0 && z >= 0 && x < gridArray.GetLength(0) && z < gridArray.GetLength(1))
            gridArray[x, z] = !GetState(x, z);
    }

    public void SetState(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetState(x, z);
    }

    public bool GetState(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < gridArray.GetLength(0) && z < gridArray.GetLength(1))
            return gridArray[x, z];
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
