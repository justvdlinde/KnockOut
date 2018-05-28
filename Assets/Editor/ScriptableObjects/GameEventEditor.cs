using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor {

    GameEvent gameEvent;

    private void OnEnable() {
        gameEvent = (GameEvent)target;
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        GUI.enabled = Application.isPlaying;
        if (GUILayout.Button("Raise")) {
            gameEvent.Raise();
        }
        GUI.enabled = true;
    }
}