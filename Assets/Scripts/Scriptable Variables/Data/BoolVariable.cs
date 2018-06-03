using System;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver {

    //[NonSerialized]
    public bool runTimeValue;
    public bool initialValue;

    public void OnAfterDeserialize() {
        runTimeValue = initialValue;
    }

    public void OnBeforeSerialize() { }
}
