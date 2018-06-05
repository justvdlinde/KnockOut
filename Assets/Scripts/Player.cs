using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

    public float startingHealth = 100;
    // syncVar?
    public FloatVariable healthPoints;

    private void Start() {
        if(photonView.isMine)
            healthPoints.runTimeValue = startingHealth;

        foreach(HittableLimb limb in GetComponentsInChildren<HittableLimb>()) 
            limb.onHit += ProcessHit;
    }

    public void ProcessHit(PunchInfo info, float damage) {
        healthPoints.runTimeValue -= damage;
        Debug.Log("damage: " + damage);
        if (healthPoints.runTimeValue<= 0)
            KnockOut();
    }

    private void KnockOut() {
        Debug.Log("KNOCK-OUT");
    }
}
