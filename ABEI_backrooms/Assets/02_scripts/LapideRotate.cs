using System;
using UnityEngine;
public class LapideRotate : MonoBehaviour
{
    public bool correctlyRotated;
    public Vector3 correctRotation;
    public Vector3 startingRotation;

    private void Start()
    {
        startingRotation = transform.localEulerAngles;
    }
    void Update()
    {
        
    }
}