using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridVisualizer : Editor
{
    GridManager gridM;

    private void OnEnable()
    {
        gridM = target as GridManager;
        gridM.Start();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Re create grid"))
            gridM.ResetGrid();
    }

    private void OnSceneGUI()
    {
        Event guiEvent = Event.current;
        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0)
        {
            Debug.Log("Mouse left click");
        }

        Draw();

        if (guiEvent.type == EventType.Layout)
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
    }

    private void Draw()
    {
        for (int x = 0; x < gridM.grid.GetWidth(); x++)
        {
            for (int z = 0; z < gridM.grid.GetHeight(); z++)
            {
                Handles.color = (gridM.grid.GetState(x, z)) ? gridM.canPlaceColor : gridM.cantPlaceColor;
                Handles.DrawCube(GUIUtility.GetControlID(FocusType.Passive),
                                 gridM.grid.GetWorldPosition(x, z) + new Vector3(gridM.grid.GetCellSize(), 0, gridM.grid.GetCellSize()) * 0.5f,
                                 Quaternion.identity,
                                 gridM.grid.GetCellSize() * 0.9f);
            }
        }
    }

}
