using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridVisualizer : Editor
{
    Grid grid;

    private bool needRapaint;

    private void OnEnable()
    {
        grid = target as Grid;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Re create grid"))
        {
            grid.ReCreate();
            needRapaint = true;
        }
    }

    private void OnSceneGUI()
    {
        if (grid.gridAsset.gridCells != null)
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
                        grid.SetState(mousePosition);
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
    }

    private void Draw()
    {
        if (grid.gridAsset.gridCells != null)
        {
            for (int x = 0; x < grid.GetWidth(); x++)
            {
                for (int z = 0; z < grid.GetHeight(); z++)
                {
                    Handles.color = (grid.GetState(x, z)) ? grid.canPlaceColor : grid.cantPlaceColor;
                    Handles.CubeHandleCap(GUIUtility.GetControlID(FocusType.Passive),
                                     grid.GetWorldPosition(x, z) + new Vector3(grid.GetCellSize(), 0, grid.GetCellSize()) * 0.5f,
                                     Quaternion.identity,
                                     grid.GetCellSize() * 0.9f, EventType.Repaint);
                }
            }
        }
    }

}
