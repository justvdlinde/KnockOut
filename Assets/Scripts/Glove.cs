using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[SelectionBase]
public class Glove : MonoBehaviour {

    public FloatVariable charge;
    public bool isEnabled;
    public float chargeMax = 5;
    public AudioClip[] punchSounds;
    public GameObject punchParticle;

    [SerializeField]
    private OVRInput.Controller m_controller;
    public  AudioSource audioSource;
    private OVRHapticsClip clip;

    private void OnEnable() {
        InitializeOVRHaptics();
    }

    private void OnTriggerEnter(Collider collider) {
        if (!isEnabled)
            return;

        IPunchable punchableObject = collider.gameObject.GetInterface<IPunchable>();
        if (punchableObject != null)
            PunchableObjectHit(collider, punchableObject);
    }

    private void PunchableObjectHit(Collider collider, IPunchable punchableObject) {
        Debug.Log("hitting " + collider.gameObject.name);
        float velocity = CalculateVelocity();
        punchableObject.Hit(new PunchInfo(transform.position, velocity, charge.runTimeValue));
        Vibrate();
        audioSource.PlayOneShot(punchSounds.GetRandom());
        Instantiate(punchParticle, collider.ClosestPointOnBounds(transform.position), Quaternion.identity);
    }

    public float CalculateVelocity() {
        return OVRInput.GetLocalControllerVelocity(m_controller).magnitude;
    }

    //public void PlayHaptic() {
    //    if(m_controller == OVRInput.Controller.LTouch)
    //    OVRHaptics.LeftChannel.Preempt(hapticsClip);
    //}

    public void AddCharge(float charge) {
        this.charge.runTimeValue += charge;
        if (this.charge.runTimeValue > chargeMax)
            this.charge.runTimeValue = chargeMax;
    }

    public void SetCharge(float charge) {
        this.charge.runTimeValue = charge;
        if (this.charge.runTimeValue > chargeMax)
            this.charge.runTimeValue = chargeMax;
    }

    public void Enable(bool enable) {
        isEnabled = enable;
    }

    private void InitializeOVRHaptics() {
        int count = 10;
        clip = new OVRHapticsClip(count);

        for (int i = 0; i < count; i++) {
            clip.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)180;
        }

        clip = new OVRHapticsClip(clip.Samples, clip.Samples.Length);
    }

    public void Vibrate() {
        var channel = OVRHaptics.RightChannel;
        if (m_controller == OVRInput.Controller.LTouch)
            channel = OVRHaptics.LeftChannel;
        channel.Preempt(clip);
    }

}
