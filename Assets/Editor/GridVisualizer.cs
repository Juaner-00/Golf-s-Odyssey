using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridVisualizer : Editor
{
    Grid gridObj;

    private bool needRapaint;

    private void OnEnable()
    {
        gridObj = target as Grid;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Re create grid"))
        {
            gridObj.Create();
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
                    gridObj.SetState(mousePosition);
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
        if (gridObj.GridObj.gridCells != null)
        {
            for (int x = 0; x < gridObj.Width; x++)
            {
                for (int z = 0; z < gridObj.Height; z++)
                {
                    Handles.color = (gridObj.GetState(x, z)) ? gridObj.CanPlaceColor : gridObj.CannotPlaceColor;
                    Handles.CubeHandleCap(GUIUtility.GetControlID(FocusType.Passive),
                                     gridObj.GetWorldPosition(x, z) + new Vector3(gridObj.CellSize, 0, gridObj.CellSize) * 0.5f,
                                     Quaternion.identity,
                                     gridObj.CellSize * 0.9f, EventType.Repaint);
                }
            }
        }
    }

}
