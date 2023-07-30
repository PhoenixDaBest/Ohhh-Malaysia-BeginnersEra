using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight1 : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The constant speed of movement along the x-axis

    public Animator planeAnim;
    bool start = false;

    public bool mainCam;


    void Start()
    {
        StartCoroutine(startSeq());
    }

    private void Update()
    {
        if(start)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    IEnumerator startSeq()
    {
        yield return new WaitForSeconds(2);

        if(mainCam)
            planeAnim.SetBool("startGame", true);

        yield return new WaitForSeconds(3);

        start = true;

    }
}
