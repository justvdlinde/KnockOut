using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {

    private Rigidbody rb;

    private static Ragdoll instance;
    public static Ragdoll Instance { get{ return instance; } }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        instance = this;
	}
	
    public void Dead() {
        rb.isKinematic = false;
        Debug.Log("dead");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
