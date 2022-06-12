using System;
using UnityEngine;
public class LapideRotate : MonoBehaviour
{
    public bool correctlyRotated;
    public float correctRotation;
    public float startingRotation;

    private void Start()
    {
        transform.Rotate(0f,startingRotation,0f);
    }

    void Update()
    {
        if (correctRotation == transform.localEulerAngles.y)
        {
            correctlyRotated = true;
        }
    }
}