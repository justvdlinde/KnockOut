using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {

    private GameObject playerRot;
    private GameObject playerPos;
    private SkinnedMeshRenderer handLeft;
    private SkinnedMeshRenderer handRight;
    private SkinnedMeshRenderer playerMesh;


    private Transform rootRot;
    private Transform rootPos;
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
        playerMesh = GameObject.Find("body_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        handLeft = GameObject.Find("hand_left_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        handRight = GameObject.Find("hand_right_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        rootRot = GameObject.Find("root")       .transform;
        rootPos = GameObject.Find("chest_JNT")  .transform;
        hackActivated = true;
    }

    private void Update()
    {
        if (hackActivated) {
            avatar.transform.rotation = rootRot.transform.rotation;
            avatar.transform.position = rootPos.transform.position;
            playerRot.GetComponent<SkinnedMeshRenderer>().enabled = false;
            playerPos.GetComponent<SkinnedMeshRenderer>().enabled = false;
            playerMesh.enabled =                                    false;
            handLeft.enabled = false;
            handRight.enabled = false;
        }
    }
}
