using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public TMP_Text pointsText;
    public float pointsIncreaseRate = 1f; // Adjust this value to control the rate of points increase

    private int points = 0;
    private float timer;

    public bool start = false;

    void Start()
    {
        StartCoroutine(startSeq());
    }


    void Update()
    {
        if (start)
        {
            // Count down the timer
            timer -= Time.deltaTime;

            // Check if it's time to increase points
            if (timer <= 0f)
            {
                IncreasePoints();
                timer = pointsIncreaseRate;
            }
        }
    }

    void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
    }

    IEnumerator startSeq()
    {
        yield return new WaitForSeconds(4f);

        start = true;
    }
}
