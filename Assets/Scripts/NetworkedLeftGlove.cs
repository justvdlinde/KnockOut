using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedLeftGlove : Photon.MonoBehaviour {

    public GameObject leftGlove;
    public Transform playerGlobal;
    public Transform playerLocal;

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    void Start(){
        if (photonView.isMine){
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor");
            transform.SetParent(playerLocal, false);
            transform.localPosition = Vector3.zero;
            // avatar.SetActive(false);
        }
    }
    //private void Update()
    //{
    //    if (!photonView.isMine) {
    //        transform.position = Vector3.Lerp(leftGlove.transform.position, playerLocal.position , Time.deltaTime * 15);
    //    }
    //}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.localRotation);
        }
        else
        {
            realPosition = (Vector3)stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();
            leftGlove.transform.position = (Vector3)stream.ReceiveNext();
            leftGlove.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
