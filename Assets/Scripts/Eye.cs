using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Eye : Photon.MonoBehaviour {

    public FloatMinMax xClamp, yClamp, zClamp;

    private Transform target;
    private Vector3 originalRot;

    private void Start() {
        originalRot = transform.eulerAngles;

    }

    public void LateUpdate() {
        if (target != null) {

            transform.LookAt(target);
            Vector3 rot = transform.eulerAngles;
            rot.x = Helper.ClampAngle(rot.x, xClamp.min, xClamp.max);
            rot.y = Helper.ClampAngle(rot.y, yClamp.min, yClamp.max);
            rot.z = Helper.ClampAngle(rot.z, zClamp.min, zClamp.max);
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
        if (focus != null && focus.transform.parent != transform.parent) {
            print(focus);
            target = focus.transform;
            Debug.Log("Found eye follow target");
            GetComponent<Collider>().enabled = false;
        }
    }

}
