using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfBeta : MonoBehaviour
{
    public string sceneToLoad;
    public float fadeDuration = 1.0f;
    public GameObject fadePanelPrefab;
    public FIn fin;
    private GameObject fadePanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player")) // Replace "Player" with the tag of the object that will trigger the scene change
        //{
            fin.FadeIn();
            StartCoroutine(Transition());
            
       // }
       Debug.Log("hey");
    }

    IEnumerator Transition()
    {
        fadePanel = Instantiate(fadePanelPrefab, Vector3.zero, Quaternion.identity);
        CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
        float fadeSpeed = 1.0f / fadeDuration;
        float alpha = 0.0f;

        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = Mathf.Clamp01(alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);

        while (alpha > 0.0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = Mathf.Clamp01(alpha);
            yield return null;
        }

        Destroy(fadePanel);
    }
}