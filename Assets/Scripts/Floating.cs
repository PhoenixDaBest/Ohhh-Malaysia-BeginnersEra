using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating movement
    public float floatAmount = 1.0f; // Amount of floating displacement

    private Vector3 startPos;       // Initial position of the object

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new vertical position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount;

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
