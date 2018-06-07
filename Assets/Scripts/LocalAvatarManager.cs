using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAvatarManager : MonoBehaviour
{
    private SkinnedMeshRenderer handLeft;
    private SkinnedMeshRenderer handRight;
    private bool hackActivated;
    GameObject[] objs;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("DeleteAvatar");
    }

    IEnumerator DeleteAvatar()
    {
        yield return new WaitForSeconds(2);
        handLeft = GameObject.Find("hand_left_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        handRight = GameObject.Find("hand_right_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        hackActivated = true;
    }

    private void Update()
    {
        if (hackActivated)
        {
            Debug.Log(handLeft.enabled);
            handLeft.enabled = false;
            handRight.enabled = false;
        }
        objs = GameObject.FindGameObjectsWithTag("deleteMesh");
        foreach (GameObject obj in objs) {
            obj.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
}
