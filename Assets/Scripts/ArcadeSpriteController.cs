using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeSpriteController : MonoBehaviour {

    public FloatMinMax switchTime = new FloatMinMax(.2f, 2f);

    public GameObject[] rends;
    public GameObject currentRend;

    private void Start() {
        rends = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            rends[i] = transform.GetChild(i).gameObject;
            rends[i].SetActive(false);
        }

        currentRend = rends.GetRandom();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait() {
        float rndTime = switchTime.GetRandom();
        GameObject rndSprite = rends.GetRandom();
        currentRend.SetActive(false);
        currentRend = rndSprite;
        currentRend.SetActive(true);
        yield return new WaitForSeconds(rndTime);
        StartCoroutine(Wait());
    }
}
