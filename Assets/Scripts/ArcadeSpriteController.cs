using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeSpriteController : MonoBehaviour {

    public FloatMinMax minMax = new FloatMinMax(.2f, 2f);

    private SpriteRenderer rend;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait() {
        float rnd = minMax.GetRandom();
        yield return new WaitForSeconds(rnd);
        rend.enabled = !rend.enabled;
        StartCoroutine(Wait());
    }
}
