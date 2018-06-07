﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchInfo  {

    public Vector3 position;
    public float velocity;
    public float charge;

    public PunchInfo(Vector3 position, float velocity, float charge) {
        this.position = position;
        this.velocity = velocity;
        this.charge = charge;
    }
}
