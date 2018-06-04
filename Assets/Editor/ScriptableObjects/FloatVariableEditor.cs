using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatVariable))]
public class FloatVariableEditor : Editor {

    FloatVariable obj;
    float floatVar;

    private void OnEnable() {
        obj = (FloatVariable)target;
    }

    public override void OnInspectorGUI() {
        base.DrawDefaultInspector();
        floatVar = obj.runTimeValue;
        floatVar = EditorGUILayout.FloatField("Runtime Value", floatVar);
        obj.runTimeValue = floatVar;
    }
}