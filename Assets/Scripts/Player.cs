using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float startingHealth = 100;
    // syncVar?
    public float healthPoints;

    private void Start() {
        healthPoints = startingHealth;

        foreach(HittableLimb limb in GetComponentsInChildren<HittableLimb>()) 
            limb.onHit += ProcessHit;
    }

    public void ProcessHit(PunchInfo info, float damage) {
        healthPoints -= damage;
        Debug.Log("damage: " + damage);
        if (healthPoints <= 0)
            KnockOut();
    }

    private void KnockOut() {
        Debug.Log("KNOCK-OUT");
    }
}
