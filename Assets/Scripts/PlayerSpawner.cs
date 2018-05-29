using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Photon.MonoBehaviour {

    public Transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        //if (NetworkController.numOfPlayers == 0)
        //{
        //    Debug.Log("Moving to spawnpoint 1");
        //    transform.position = spawnPoints[0].position;
        //    transform.rotation = spawnPoints[0].rotation;
        //}

        //if (NetworkController.numOfPlayers == 1)
        //{
        //    Debug.Log("Moving to spawnpoint 2");
        //    transform.position = spawnPoints[1].position;
        //    transform.rotation = spawnPoints[1].rotation;
        //}
    }

    private void Update()
    {
    }
}
