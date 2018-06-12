using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveRecharger : MonoBehaviour {

    public float chargeValue = 1;

    public Glove left, right;
    public float minRechargeDistance = 1;

    public void Update() {
        if (Vector3.Distance(transform.position, left.transform.position) < minRechargeDistance)
            RechargeGlove(left);
        if (Vector3.Distance(transform.position, right.transform.position) < minRechargeDistance)
            RechargeGlove(right);
    }

    //public void OnTriggerEnter(Collider other) {
    //    Debug.Log(other.gameObject.name); 
    //    Glove glove = other.GetComponent<Glove>();
    //    if (glove != null) {
    //        glove.Enable(true);
    //        float dif = chargeValue - glove.charge.runTimeValue;
    //        if(dif > 0)
    //            glove.AddCharge(dif);
    //    }
    //}

    private void RechargeGlove(Glove glove) {
        Debug.Log("charge " + glove.name);
        glove.Enable(true);
        float dif = chargeValue - glove.charge.runTimeValue;
        if (dif > 0)
            glove.AddCharge(dif);
    }
}
