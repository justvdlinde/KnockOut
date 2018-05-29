using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : Photon.MonoBehaviour {

    public Transform target;

    public FloatMinMax xClamp, yClamp, zClamp;

    private Vector3 originalRot;

    private void Start() {
        originalRot = transform.eulerAngles;

    }

    public void LateUpdate() {
        if (target != null) {

            transform.LookAt(target);
            Vector3 rot = transform.eulerAngles;
            rot.x = Helper.ClampAngle(rot.x, xClamp.min, xClamp.max) ;
            rot.y = Helper.ClampAngle(rot.y, yClamp.min, yClamp.max) ;
            rot.z = Helper.ClampAngle(rot.z, zClamp.min, zClamp.max) ;
            transform.eulerAngles = rot;

        } else {
            transform.eulerAngles = originalRot;
        }
    }

    //private void OnPhotonPlayerConnected() {
    //    target = FindObjectOfType<Player>().transform;
    //}

    private void OnTriggerEnter(Collider other) {
        EyeFocusTarget focus = other.GetComponent<EyeFocusTarget>();
<<<<<<< HEAD
        if(focus != null) { 
            if(focus.transform.parent != transform.parent) {
                target = focus.transform;
                Debug.Log("setting target");
                GetComponent<Collider>().enabled = false;
            }
=======
        if(focus.transform.parent != transform.parent) {
            target = focus.transform;
            Debug.Log("Found eye follow target");
            GetComponent<Collider>().enabled = false;
>>>>>>> ecda9c3a2dd530b3fdd2ac27f535cfc4f17f01a9
        }
    }

}
