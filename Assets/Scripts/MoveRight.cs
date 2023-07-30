using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The constant speed of movement along the x-axis

    private void Update()
    {
        // Move the object along the x-axis at the constant speed
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
