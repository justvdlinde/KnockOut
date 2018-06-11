using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Shield : MonoBehaviour {

    public AudioClip hit, down, up;
    public AudioSource audioSource;
    public bool isLocal;

    public static Action<Shield> onShieldCreated;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        if (onShieldCreated != null) {
            onShieldCreated.Invoke(this);
        }

        gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider collider) {
        //if (collider.GetComponent<PhotonView>() && collider.GetComponent<PhotonView>().isMine)
        //    return;

        Glove glove = collider.gameObject.GetComponent<Glove>();
        if (glove != null) {
            glove.Enable(false);
            glove.SetCharge(0);
            audioSource.PlayOneShot(hit);
        }
    }

    private void OnEnable() {
            audioSource.PlayOneShot(up);
    }

    private void OnDisable() {
            audioSource.PlayOneShot(down);
    }
}
