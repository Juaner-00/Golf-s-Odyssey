using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelsObject))]
public class LevelEditor : Editor
{
    LevelsObject lvlObj;


    private void OnEnable()
    {
        lvlObj = target as LevelsObject;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset"))
        {
            lvlObj.ReCreate();
        }
    }

}
