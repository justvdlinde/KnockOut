using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedRightGlove : Photon.MonoBehaviour {

    public GameObject rightGlove;
    public Transform playerGlobal;
    public Transform playerLocal;

    void Start(){
        Debug.Log("Body Instantiated");
        if (photonView.isMine){
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");
            transform.SetParent(playerLocal, false);
            transform.localPosition = Vector3.zero;

            // avatar.SetActive(false);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.isWriting){
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.localRotation);
        }
        else{
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            rightGlove.transform.position = (Vector3)stream.ReceiveNext();
            rightGlove.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
