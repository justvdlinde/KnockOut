using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

    public int index;
    public float startingHealth = 100;
    public FloatVariable healthPoints;
    public GameEvent onDamageTakenEvent;
    public float health;
    public BlockManager blockManager;

    public AudioClip[] grunts;
    public Animator animator;
    public AnimationClip[] hitAnims;

    public AudioSource audioSource;

    private void Start() {
        index = photonView.viewID;

        if (photonView.isMine)
            healthPoints.runTimeValue = startingHealth;

        foreach (HittableLimb limb in GetComponentsInChildren<HittableLimb>())
            limb.onHit += ProcessHit;
    }

    private void Update() {
        health = healthPoints.runTimeValue;
    }

    public void ProcessHit(PunchInfo info, float damage) {
        photonView.RPC("DamagePlayer", PhotonTargets.All, damage, index);
        healthPoints.runTimeValue -= damage;
    }

    [PunRPC]
    private void DamagePlayer(float damage, int senderIndex) {
        if (!photonView.isMine) {
            audioSource.PlayOneShot(grunts.GetRandom());
            PlayRandomHitAnimation();
        }

        //if (index == senderIndex)
        //    return;

        healthPoints.runTimeValue -= damage;
        Debug.Log("damage recieved: " + damage);
        if (onDamageTakenEvent != null)
            onDamageTakenEvent.Raise();

        if (healthPoints.runTimeValue <= 0)
            KnockOut();
    }

    private void KnockOut() {
        Debug.Log("KNOCK-OUT");
    }

    private void PlayRandomHitAnimation() {
        string rndClip = hitAnims.GetRandom().name;
        animator.CrossFade(rndClip, .1f, 0);
    }

    private void OnGUI() {
        if (photonView.isMine) { 
            GUI.Label(new Rect(10, 10, 1000, 20), "HP: " + healthPoints.runTimeValue);
            GUI.Label(new Rect(10, 30, 1000, 20), "index: " + index);
        }
    }

    //void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    //    if (stream.isWriting) {
    //        stream.SendNext(healthPoints.runTimeValue);
    //    }

    //    if (stream.isReading) {
    //        healthPoints.runTimeValue = (float)stream.ReceiveNext();
    //    }
    //}
}
