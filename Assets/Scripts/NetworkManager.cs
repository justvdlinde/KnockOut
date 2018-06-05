using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    private string _room = "Test_Room";
    private PhotonView photonView;
    public readonly byte InstantiateVrAvatarEventCode = 123;
    [SerializeField]
    public Transform[] spawnpoints;

    void Start() {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnJoinedLobby() {
        Debug.Log("Joined Lobby");

        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }


    public void OnJoinedRoom() {
        int viewId = PhotonNetwork.AllocateViewID();
        PhotonNetwork.RaiseEvent(InstantiateVrAvatarEventCode, viewId, true, new RaiseEventOptions() { CachingOption = EventCaching.AddToRoomCache, Receivers = ReceiverGroup.All });
        Debug.Log(viewId);
    }


    private void OnEvent(byte eventcode, object content, int senderid) {
        if (eventcode == InstantiateVrAvatarEventCode) {
            GameObject go = null;

            if (PhotonNetwork.player.ID == senderid){
                go = Instantiate(Resources.Load("LocalAvatar")) as GameObject;
                if (PhotonNetwork.countOfPlayers == 1) {
                    go.transform.position = spawnpoints[0].position;
                    Debug.Log("spawned at pos 1");
                }
                else {
                    go.transform.position = spawnpoints[1].position;
                    Debug.Log("spawned at pos 2");
                }
                
            }
            else {
                go = Instantiate(Resources.Load("RemoteAvatar")) as GameObject;
                    if (PhotonNetwork.countOfPlayers == 0) {
                        go.transform.position = spawnpoints[1].position;
                    }
                    else {
                    go.transform.position = spawnpoints[0].position;
                }
            }

            if (go != null) {
                PhotonView pView = go.GetComponent<PhotonView>();

                if (pView != null) {
                    pView.viewID = (int)content;
                }
            }
        }
    }

    public void OnEnable() {
        PhotonNetwork.OnEventCall += OnEvent;
    }

    public void OnDisable(){
        PhotonNetwork.OnEventCall -= OnEvent;
    }


}
