using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class InstrumentSO : ScriptableObject
{
    public Transform prefab;
    public string objectName;
    public AudioClip clip;
    public int measureCount;


}
