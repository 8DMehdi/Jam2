using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip hurtSound; // Référence à l'audio à jouer lors de la collision
    public float pushBackForce = 5f; // Force de recul lors de la collision

    private AudioSource audioSource;

    void Start()
    {
        // Assurez-vous que le GameObject a un composant AudioSource attaché
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision a le tag "enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision avec un ennemi détectée!"); // Déboguer la collision
            // Calculer la direction du recul en utilisant la position de l'ennemi et du joueur
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.y = 0; // Ignorer la composante verticale

            // Appliquer la force de recul au joueur
            GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushBackForce, ForceMode.Impulse);

            // Jouer le son de collision
            if (hurtSound != null)
            {
                audioSource.PlayOneShot(hurtSound);
            }
        }
    }
}
