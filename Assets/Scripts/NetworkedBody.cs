using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedBody : Photon.MonoBehaviour {

    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    public bool showBody = false;

    void Start() {
        if (photonView.isMine) {
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
            transform.SetParent(playerLocal, false);
            transform.localPosition = Vector3.zero;
            avatar.SetActive(showBody);
        }
    }


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.isWriting){
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.localRotation);
        }
        else {
            realPosition = (Vector3)stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.position = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
