using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 5f; // Vitesse de deplacement de l'ennemi
    public Transform player; // Reference au transform du joueur
    public float detectionRadius = 35f; // Rayon de detection du joueur

    private bool playerInRange = false; // Indique si le joueur est dans la zone de detection

    // Methode appelee a chaque frame
    void Update()
    {
        // Si le joueur est dans la zone de detection
        if (playerInRange && player != null)
        {
            // Calculer la direction vers laquelle se diriger (direction du joueur)
            Vector3 direction = (player.position - transform.position).normalized;

            // Deplacer l'ennemi dans la direction du joueur a la vitesse specifiee
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Methode appelee lorsque quelque chose entre dans le collider de detection de l'ennemi
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifier si l'objet entrant est le joueur
        if (other.CompareTag("Player"))
        {
            // Le joueur est maintenant dans la zone de detection
            playerInRange = true;

            // Stocker une reference au transform du joueur
            player = other.transform;
        }
    }

    // Methode appelee lorsque quelque chose sort du collider de detection de l'ennemi
    void OnTriggerExit2D(Collider2D other)
    {
        // Verifier si l'objet sortant est le joueur
        if (other.CompareTag("Player"))
        {
            // Le joueur n'est plus dans la zone de detection
            playerInRange = false;
        }
    }
}