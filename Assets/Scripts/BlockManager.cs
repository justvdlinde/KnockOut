using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Glove rightGlove, leftGlove;
    public GameObject shieldObject;
    public float maxDistanceBetweenGloves;

    public bool isBlocking;
    private Quaternion shieldRot;
    private PhotonView photonView;
    private Player player;

    public bool isBlockingSyncTest;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Shield.onShieldCreated += SetShield;
        player = GetComponent<Player>();
    }

    private void OnDestroy()
    {
        Shield.onShieldCreated -= SetShield;

    }

    private void Update() {
        if (shieldObject == null) 
            return;
        if(photonView.isMine)
            isBlocking = IsBlocking();

        shieldObject.SetActive(isBlocking);
        if (isBlocking)
            Block();

        //if (photonView.isMine)
            ProcessBlock(isBlocking);

        isBlockingSyncTest = isBlocking;
    }

    [PunRPC]
    private void SyncShield(bool b, int senderIndex) {
        //if (player.index == senderIndex)
        //    return;
        isBlocking = b;
    }

    public void ProcessBlock(bool b) {
        photonView.RPC("SyncShield", PhotonTargets.All, b, player.index);
    }

    private void SetShield(Shield shield) {
        if (photonView.isMine)
        {
            if (shield.isLocal)
                shieldObject = shield.gameObject;
        }
        else
        {
            if(!shield.isLocal)
                shieldObject = shield.gameObject;
        }
    }

    private void Block() {
        shieldObject.transform.position = (rightGlove.transform.position + leftGlove.transform.position) / 2;
        shieldRot = Quaternion.Slerp(rightGlove.transform.rotation, leftGlove.transform.rotation, 0.5f);
        shieldObject.transform.rotation = shieldRot;
    }

    private bool IsBlocking() {
        return DistanceRequirementMet() &&
               OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0 &&
               OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0 &&
               rightGlove.charge.runTimeValue > 0 && leftGlove.charge.runTimeValue > 0;
    }

    private bool DistanceRequirementMet() {
        return Vector3.Distance(rightGlove.transform.position, leftGlove.transform.position) < maxDistanceBetweenGloves;
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(isBlockingSyncTest);
        }

        if (stream.isReading) {
            isBlockingSyncTest = (bool)stream.ReceiveNext();
        }
    }
}
