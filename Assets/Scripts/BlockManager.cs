using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Transform rightGlove, leftGlove;
    public GameObject shieldObject;
    public float maxDistanceBetweenGloves;
    public FloatMinMax yRotation, zRotation, xRotation;

    private bool isBlocking;
    
    private void Update() {
        isBlocking = IsBlocking();
        shieldObject.SetActive(isBlocking);
        if(isBlocking)
            Block();
    }

    private void Block() {
        shieldObject.transform.position = (rightGlove.position + leftGlove.position) / 2;
        Quaternion rot = Quaternion.Slerp(rightGlove.rotation, leftGlove.rotation, 0.5f);
        shieldObject.transform.rotation = rot;
    }

    private bool IsBlocking() {
        return GloveRequirementsAreMet(); 
    }

    private bool GloveRequirementsAreMet() {
        return Vector3.Distance(rightGlove.position, leftGlove.position) < maxDistanceBetweenGloves;
               //Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x) < xRotation &&
               //Mathf.Abs(leftGlove.transform.rotation.y - rightGlove.transform.rotation.y) < yRotation &&
               //Mathf.Abs(leftGlove.transform.rotation.z - rightGlove.transform.rotation.z) < zRotation;
    }

    private void OnGUI() {
        GUILayout.BeginVertical();
        //GUILayout.Label("isblocking: " + IsBlocking());
        //GUILayout.Label("charge: " + blockCharge.runTimeValue);
        //GUILayout.Label("Rot: " + shieldObject.transform.rotation);
        //    GUILayout.Label("CONDITIONS MET: " + conditionsMet.runTimeValue);
        //    GUILayout.Label("Distance " + Vector3.Distance(rightGlove.position, leftGlove.position));
        //    GUILayout.Label("angle dif X " + Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x));
        GUILayout.EndVertical();
    }
}
