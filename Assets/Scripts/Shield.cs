using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

    public void OnTriggerEnter(Collider collider) {
        //if (collider.GetComponent<PhotonView>() && collider.GetComponent<PhotonView>().isMine)
        //    return;

        Glove glove = collider.gameObject.GetComponent<Glove>();
        if (glove != null) {
            glove.Enable(false);
            glove.SetCharge(0);
        }
    }
}
