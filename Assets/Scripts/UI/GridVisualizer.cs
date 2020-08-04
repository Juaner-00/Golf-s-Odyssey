using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridVisualizer : Editor
{
    GridManager gridM;

    private bool needRapaint;

    private void OnEnable()
    {
        gridM = target as GridManager;
        gridM.Init();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Re create grid"))
        {
            gridM.ResetGrid();
            needRapaint = true;
        }
    }

    private void OnSceneGUI()
    {
        Event guiEvent = Event.current;

        Ray mouseRay = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
        float drawPlaneHeight = 0;
        float distToDrawPlane = (drawPlaneHeight - mouseRay.origin.y) / mouseRay.direction.y;
        Vector3 mousePosition = mouseRay.GetPoint(distToDrawPlane);


        if (guiEvent.type == EventType.MouseDown)
        {
            switch (guiEvent.button)
            {
                case 0:
                    gridM.SetState(mousePosition);
                    needRapaint = true;
                    break;
                default:
                    break;
            }
        }

        Draw();

        if (guiEvent.type == EventType.Layout)
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        if (needRapaint)
        {
            HandleUtility.Repaint();
            needRapaint = false;
        }
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
