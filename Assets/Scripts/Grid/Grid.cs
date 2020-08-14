using System;
using UnityEngine;
public class Grid : MonoBehaviour
{
    [SerializeField]
    GridObject gridObj;

    [SerializeField]
    int height = 10, width = 10;

    [SerializeField]
    float cellSize = 1;

    [SerializeField]
    Vector3 originPosition = new Vector3();

    [SerializeField]
    Color canPlaceColor = new Color(0, 1, 0, 0.5f), cannotPlaceColor = new Color(1, 0, 0, 0.5f);


    public void Create()
    {
        gridObj.gridCells = new bool[width * height];
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
        if (x >= 0 && z >= 0 && x < width && z < height)
            try
            {
                gridObj.gridCells[x + z * width] = !GetState(x, z);
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogError("Debe recrear el grid");
            }
    }

    public void SetState(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetState(x, z);
    }

    public bool GetState(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            try
            {
                return gridObj.gridCells[x + z * width];
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogError("Debe recrear el grid");

                return false;
            }
        }
        else
            return false;
    }

    public bool GetState(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetState(x, z);
    }

    // Accesores
    public int Height { get => height; }
    public int Width { get => width; }
    public float CellSize { get => cellSize; }
    public GridObject GridObj { get => gridObj; }
    public Color CanPlaceColor { get => canPlaceColor; }
    public Color CannotPlaceColor { get => cannotPlaceColor; }
}