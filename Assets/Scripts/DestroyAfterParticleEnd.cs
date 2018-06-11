using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyAfterParticleEnd : MonoBehaviour {

    private void Start() {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
