using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(1f, 1f, 0);
    [SerializeField] float period = 2f;
    [SerializeField] float movementOffset = 0.5f;

    float movementFactor; // 0 for not moved, 1 for fully moved.
    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // protect against period is zero
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau)*5; // goes from -1 to +1

        movementFactor = rawSinWave / 2f + movementOffset;
        Vector3 offset = movementFactor * movementVector;
        transform.localScale = startingPos + offset;
    }
}
