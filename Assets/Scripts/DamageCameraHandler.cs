using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class DamageCameraHandler : MonoBehaviour {

    public AnimationCurve effectCurve;
    public float effectDuration;
    public float effectIntensity;

    private VignetteModel vignette;
    private Coroutine currentkyPlayingCoroutine;
    private float startingIntensity;

    private void Start() {
        vignette = GetComponent<PostProcessingBehaviour>().profile.vignette;
        startingIntensity = vignette.settings.intensity;
    }

    public void ExecuteEffect() {
        if (currentkyPlayingCoroutine != null)
            StopCoroutine(currentkyPlayingCoroutine);
        currentkyPlayingCoroutine = StartCoroutine(EffectCoroutine());
    }

    private IEnumerator EffectCoroutine() {
        float timer = 0;
        VignetteModel.Settings temp = vignette.settings;

        while (timer < effectDuration) {
            float lerp = effectCurve.Evaluate(timer / effectDuration);
            float lerpedIntensity = Mathf.Lerp(startingIntensity, effectIntensity, lerp);
            temp.intensity = lerpedIntensity;
            vignette.settings = temp;
            timer += Time.deltaTime;
            yield return null;
        }

        temp = vignette.settings;
        temp.intensity = startingIntensity;
        vignette.settings = temp;
    }
}
