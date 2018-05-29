using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedRightGlove : Photon.MonoBehaviour {

    public GameObject rightGlove;
    public Transform playerGlobal;
    public Transform playerLocal;

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    void Start(){
        if (photonView.isMine){
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");
            transform.SetParent(playerLocal, true);
            transform.localPosition = Vector3.zero;

            // avatar.SetActive(false);
        }
    }



    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //stream.SendNext(playerGlobal.position);
            //stream.SendNext(playerGlobal.rotation);
            //stream.SendNext(playerLocal.position);
            //stream.SendNext(playerLocal.localRotation);
        }
        else
        {
            //realPosition = (Vector3)stream.ReceiveNext();
            //realRotation = (Quaternion)stream.ReceiveNext();
            //rightGlove.transform.position = (Vector3)stream.ReceiveNext();
            //rightGlove.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
