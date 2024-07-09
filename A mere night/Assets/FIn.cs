using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIn : MonoBehaviour
{
    public float duration = 1.0f; // Duration of the transition in seconds
    private float timer = 0.0f;   // Timer to track elapsed time

    public void FadeIn()
    {
        StartCoroutine(ChangeAlphaOverTime());
    }

    IEnumerator ChangeAlphaOverTime()
    {
        Color startColor = GetComponent<Renderer>().material.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // Set alpha to 1 (255)

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            Color currentColor = Color.Lerp(startColor, endColor, progress);
            GetComponent<Renderer>().material.color = currentColor;
            yield return null;
        }

        // Ensure final color is exactly the end color
        GetComponent<Renderer>().material.color = endColor;
    }     
}