using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

    public int index;
    public float startingHealth = 100;
    public FloatVariable healthPoints;
    public GameEvent onDamageTakenEvent;
    public GameEvent onKnockedOutEvent;
    public float health;
    public BlockManager blockManager;

    public AudioClip[] grunts;
    public Animator animator;
    public AnimationClip[] hitAnims;

    public AudioSource audioSource;
    private SoundManager sm;
    bool isKnockedOut = false;

    private void Start() {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
        photonView.RPC("DamagePlayer", PhotonTargets.Others, damage, index);
        healthPoints.runTimeValue -= damage;
        audioSource.PlayOneShot(grunts.GetRandom());
        PlayRandomHitAnimation();
    }

    [PunRPC]
    private void DamagePlayer(float damage, int senderIndex) {
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
        if (isKnockedOut == true)
            return;
        Debug.Log("KNOCK-OUT");
        sm.KnockoutSound();
        onKnockedOutEvent.Raise();
        isKnockedOut = true;
        enabled = false;
        Ragdoll.Instance.Dead();
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
    //        stream.SendNext(health);
    //    }

    //    if (stream.isReading) {
    //        health = (float)stream.ReceiveNext();
    //    }
    //}
}
