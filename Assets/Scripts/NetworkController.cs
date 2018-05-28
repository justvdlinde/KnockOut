using System;
using UnityEngine;

public class NetworkController : MonoBehaviour {

    [SerializeField]
    private Transform[] spawnPoints;
    private string _room = "Test_Room";

    public GameObject playerSpawn;

    public static Action OnStuffSpawnedReady;


	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}

    private void Update() {
    }

    void OnJoinedLobby() {
        Debug.Log("Joined Lobby");
        
        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom() {
        //playerSpawn.transform.position = spawnPoints[PhotonNetwork.countOfPlayers].position;
        //playerSpawn.transform.rotation = spawnPoints[PhotonNetwork.countOfPlayers].rotation;
        if (PhotonNetwork.countOfPlayers == 1)
        {
            Debug.Log("Moving to spawnpoint 1");
            playerSpawn.transform.position = spawnPoints[0].position;
            playerSpawn.transform.rotation = spawnPoints[0].rotation;
        }

        if (PhotonNetwork.countOfPlayers == 2)
        {
            Debug.Log("Moving to spawnpoint 2");
            playerSpawn.transform.position = spawnPoints[1].position;
            playerSpawn.transform.rotation = spawnPoints[1].rotation;
        }

        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("NetworkedLeftGlove", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("NetworkedRightGlove", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("Shield", Vector3.zero, Quaternion.identity, 0);



        if (OnStuffSpawnedReady != null)
            OnStuffSpawnedReady.Invoke();
    }
}
