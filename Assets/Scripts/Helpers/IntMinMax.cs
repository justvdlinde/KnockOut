using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IntMinMax {

    public int min, max;

    public IntMinMax(int min, int max) {
        this.min = min;
        this.max = max;
    }

    public int GetRandom() {
        return Random.Range(min, max);
    }
}
