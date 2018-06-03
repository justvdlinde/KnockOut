using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveRecharger : MonoBehaviour {

    public float chargeValue = 1;

    public void OnTriggerEnter(Collider other) {
        Glove glove = other.GetComponent<Glove>();
        if (glove != null) {
            glove.Enable(true);
            float dif = chargeValue - glove.charge.runTimeValue;
            if(dif > 0)
                glove.AddCharge(dif);
        }
    }
}
