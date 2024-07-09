using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public int value;
    public AudioClip collectSound; // Variable pour le son de la collecte
    private AudioSource audioSource; // Variable pour le composant AudioSource

    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Ajouter le composant AudioSource au gameObject
        audioSource.clip = collectSound; // Assigner le clip audio à l'AudioSource
        audioSource.playOnAwake = false; // Empêcher la lecture automatique du son
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play(); // Jouer le son de collecte
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }

}
