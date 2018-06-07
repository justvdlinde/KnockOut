using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Photon.MonoBehaviour {

    public FloatVariable health;
    public Color fullColor, emptyColor;
    public bool destroyIfNotMine = true;
    public new Renderer renderer;
    public float fullHP;
    public float emptyHP = 0;

    private float lerp;

    private void Start() {
        if (destroyIfNotMine && photonView != null && !photonView.isMine)
            Destroy(gameObject);

        fullHP = health.initialValue;
    }

    private void Update() {
        renderer.material.color = Color.Lerp(emptyColor, fullColor, health.runTimeValue / 100);
    }
}
