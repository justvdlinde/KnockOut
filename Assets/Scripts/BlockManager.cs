using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Transform rightGlove, leftGlove;
    public GameObject shieldObject;
    public float maxDistanceBetweenGloves;

    private bool isBlocking;
    private Quaternion shieldRot;

    private void Update() {
        isBlocking = IsBlocking();
        shieldObject.SetActive(isBlocking);
        if (isBlocking)
            Block();
    }

    private void Block() {
        shieldObject.transform.position = (rightGlove.position + leftGlove.position) / 2;
        shieldRot = Quaternion.Slerp(rightGlove.rotation, leftGlove.rotation, 0.5f);
        shieldObject.transform.rotation = shieldRot;
    }

    private bool IsBlocking() {
        return DistanceRequirementMet() &&
               OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0 &&
               OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0;
    }

    private bool DistanceRequirementMet() {
        return Vector3.Distance(rightGlove.position, leftGlove.position) < maxDistanceBetweenGloves;
    }

    //private void OnGUI() {
    //    GUILayout.BeginVertical();
    //    //GUILayout.Label("isblocking: " + IsBlocking());
    //    //GUILayout.Label("charge: " + blockCharge.runTimeValue);
    //    //GUILayout.Label("Rot: " + shieldObject.transform.rotation);
    //    //GUILayout.Label("DISTANCE MET: " + DistanceRequirementMet());
    //    //GUILayout.Label("Distance " + Vector3.Distance(rightGlove.position, leftGlove.position));
    //    GUILayout.Label("left rot " + leftGlove.rotation);
    //    GUILayout.Label("right rot " + rightGlove.rotation);
    //    GUILayout.Label("shield rot " + shieldRot);
    //    GUILayout.EndVertical();
    //}
}
