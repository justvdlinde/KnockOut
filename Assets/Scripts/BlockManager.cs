using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Transform rightGlove, leftGlove;
    public GameObject shieldObject;
    public float maxDistanceBetweenGloves;
    public FloatMinMax yRotation, zRotation, xRotation;
    public BoolVariable isBlocking;
    public float maxBlockTime, minChargeNecessaryForBlock;
    public float chargeAddedOnBlock = 1;
    public FloatVariable blockCharge;


    private void Start()
    {
        enabled = false;
        //NetworkController.OnStuffSpawnedReady += EnableComponent;
    }

    private void EnableComponent() {
        enabled = true;
        rightGlove = GameObject.Find("NetworkedRightGlove(Clone)").transform;
        leftGlove = GameObject.Find("NetworkedLeftGlove(Clone)").transform;
        shieldObject = GameObject.Find("Shield(Clone)");
    }
    
    private void OnDestroy()
    {
        //NetworkController.OnStuffSpawnedReady -= EnableComponent;

    }

    private void Update() {
        //if (IsBlocking())
        //    ShieldUpTimer();
        //else
        //    ResetTimer();

        isBlocking.runTimeValue = IsBlocking();
        shieldObject.SetActive(isBlocking.runTimeValue);
        if (isBlocking.runTimeValue)
            Block();
    }

    private void Block() {
        shieldObject.transform.position = (rightGlove.position + leftGlove.position) / 2;
        Quaternion rot = Quaternion.Slerp(rightGlove.rotation, leftGlove.rotation, 0.5f);
        shieldObject.transform.rotation = rot;
    }

    private void ShieldUpTimer() {
        if (blockCharge.runTimeValue > 0)
            blockCharge.runTimeValue -= Time.deltaTime;
    }

    private void ResetTimer() {
        if (blockCharge.runTimeValue < maxBlockTime)
            blockCharge.runTimeValue += Time.deltaTime;
    }

    private bool IsBlocking() {
        return GloveRequirementsAreMet() && blockCharge.runTimeValue > 0; 
    }

    private bool GloveRequirementsAreMet() {
        return Vector3.Distance(rightGlove.position, leftGlove.position) < maxDistanceBetweenGloves;
               //Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x) < xRotation &&
               //Mathf.Abs(leftGlove.transform.rotation.y - rightGlove.transform.rotation.y) < yRotation &&
               //Mathf.Abs(leftGlove.transform.rotation.z - rightGlove.transform.rotation.z) < zRotation;
    }

    public void ResetCharge() {
        blockCharge.runTimeValue = maxBlockTime;
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
