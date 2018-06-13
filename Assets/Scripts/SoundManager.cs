using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip cheer;
    public AudioClip knockOut;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KnockoutSound() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(knockOut);
        audio.PlayOneShot(cheer);
        
    }
}
