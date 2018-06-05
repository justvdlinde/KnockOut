using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHand : MonoBehaviour {

    private SkinnedMeshRenderer handRight;
    private bool hackActivated;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("DeleteAvatar");
    }

    IEnumerator DeleteAvatar()
    {
        yield return new WaitForSeconds(2);
        handRight = GameObject.Find("hand_right_renderPart_0").GetComponent<SkinnedMeshRenderer>();
        hackActivated = true;
    }

    private void Update()
    {
        if (hackActivated)
        {
            handRight.enabled = false;
        }
    }
}
