using System;
using UnityEngine;

public class NetworkController : MonoBehaviour {

    public static Action OnStuffSpawnedReady;

    private string _room = "Test_Room";

	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}

    void OnJoinedLobby() {
        Debug.Log("Joined Lobby");
        
        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom() {
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("NetworkedLeftGlove", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("NetworkedRightGlove", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("Shield", Vector3.zero, Quaternion.identity, 0);

        if (OnStuffSpawnedReady != null)
            OnStuffSpawnedReady.Invoke();
    }
}
