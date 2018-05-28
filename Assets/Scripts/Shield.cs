using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

    public UnityEvent onGloveBlocked;

    public void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<PhotonView>() && collider.GetComponent<PhotonView>().isMine)
            return;

        Debug.Log("Blocked " + collider.gameObject.name);
        Glove glove = collider.gameObject.GetComponent<Glove>();
        if (glove != null) {
            glove.Enable(false);
            glove.SetCharge(0);
        }
        onGloveBlocked.Invoke();
    }
}
