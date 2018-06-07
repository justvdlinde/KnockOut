using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

    public int index;
    public float startingHealth = 100;
    public FloatVariable healthPoints;
    public GameEvent onDamageTakenEvent;
    public float health;

    private void Start() {
        index = PhotonNetwork.playerList.Length - 1;

        if(photonView.isMine)
            healthPoints.runTimeValue = startingHealth;

        foreach(HittableLimb limb in GetComponentsInChildren<HittableLimb>()) 
            limb.onHit += ProcessHit;
    }

    private void Update()
    {
        health = healthPoints.runTimeValue;
    }

    public void ProcessHit(PunchInfo info, float damage) {
        photonView.RPC("DamagePlayer", PhotonTargets.All, damage, index);
    }

    [PunRPC]
    private void DamagePlayer(float damage, int senderIndex) {
        if (index == senderIndex)
            return;

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

    private void OnGUI() {
        if (photonView.isMine) { 
            GUI.Label(new Rect(10, 10, 1000, 20), "HP: " + healthPoints.runTimeValue);
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
