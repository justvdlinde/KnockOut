using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {

    private GameObject playerRot;
    private GameObject playerPos;
    private SkinnedMeshRenderer handLeft;
    private SkinnedMeshRenderer handRight;
    private SkinnedMeshRenderer playerMesh;


    public Transform rootRot;
    public Transform rootPos;
    public GameObject avatar;
    public GameObject avatarHead;
    public bool hackActivated = false;


	void Start () {
        StartCoroutine("DeleteAvatar");
    }

    IEnumerator DeleteAvatar() {
        yield return new WaitForSeconds(2);
        playerRot = GameObject.Find("body_renderPart_2");
        playerPos = GameObject.Find("body_renderPart_1");
        rootRot = GameObject.Find("root")       .transform;
        rootPos = GameObject.Find("chest_JNT")  .transform;
        hackActivated = true;
    }

    private void Update()
    {
        if (hackActivated) {
            avatar.transform.rotation = rootRot.transform.rotation;
            avatar.transform.position = rootPos.transform.position;
        }
    }
}
