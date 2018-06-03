using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGlove : MonoBehaviour {

    private Rigidbody grabbedObjectRigidBody;
    public Transform trackPoint;
    private GameObject grabbedObject;
    public float maxDistanceDelta = 1f;
    public float minDisappearDistance = 1;

    [Tooltip("The maximum amount of velocity magnitude that can be applied to the object. Lowering this can prevent physics glitches if objects are moving too fast.")]
    public float velocityLimit = float.PositiveInfinity;
    [Tooltip("The maximum amount of angular velocity magnitude that can be applied to the object. Lowering this can prevent physics glitches if objects are moving too fast.")]
    public float angularVelocityLimit = float.PositiveInfinity;


    private void Start() {
        grabbedObject = gameObject;
        grabbedObjectRigidBody = grabbedObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 positionDelta = trackPoint.position - grabbedObject.transform.position;
        Quaternion rotationDelta = trackPoint.rotation * Quaternion.Inverse(grabbedObject.transform.rotation);

        float angle;
        Vector3 axis;
        rotationDelta.ToAngleAxis(out angle, out axis);

        angle = ((angle > 180) ? angle -= 360 : angle);

        if (angle != 0) {
            Vector3 angularTarget = angle * axis;
            Vector3 calculatedAngularVelocity = Vector3.MoveTowards(grabbedObjectRigidBody.angularVelocity, angularTarget, maxDistanceDelta);
            if (angularVelocityLimit == float.PositiveInfinity || calculatedAngularVelocity.sqrMagnitude < angularVelocityLimit) {
                grabbedObjectRigidBody.angularVelocity = calculatedAngularVelocity;
            }
        }

        Vector3 velocityTarget = positionDelta / Time.fixedDeltaTime;
        Vector3 calculatedVelocity = Vector3.MoveTowards(grabbedObjectRigidBody.velocity, velocityTarget, maxDistanceDelta);

        if (velocityLimit == float.PositiveInfinity || calculatedVelocity.sqrMagnitude < velocityLimit) {
            grabbedObjectRigidBody.velocity = calculatedVelocity;
        }
    }
}
