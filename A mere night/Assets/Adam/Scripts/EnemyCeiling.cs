using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCeiling : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public float moveSpeed = 2f;
    public float descentSpeed = 5f; // Vitesse de descente
    public float pauseDuration = 2f; // Durée de la pause au waypoint 2

    private bool playerDetected = false;
    private bool isDescending = false;
    private float pauseTimer = 0f;

    void Update()
    {
        if (playerDetected)
        {
            if (!isDescending)
            {
                // Si le joueur est détecté et l'araignée n'est pas en train de descendre, descendre vers le waypoint 2
                transform.position = Vector2.MoveTowards(transform.position, waypoint2.position, descentSpeed * Time.deltaTime);

                // Vérifier si l'araignée est arrivée au waypoint 2
                if (Vector2.Distance(transform.position, waypoint2.position) < 0.1f)
                {
                    isDescending = true; // Passer en mode descente
                    pauseTimer = 0f; // Réinitialiser le compteur de pause
                }
            }
            else
            {
                // Si l'araignée est en train de descendre
                pauseTimer += Time.deltaTime; // Compter la durée de la pause

                if (pauseTimer >= pauseDuration)
                {
                    // Si la pause est terminée, remonter vers le waypoint 1
                    transform.position = Vector2.MoveTowards(transform.position, waypoint1.position, moveSpeed * Time.deltaTime);

                    // Vérifier si l'araignée est revenue au waypoint 1
                    if (Vector2.Distance(transform.position, waypoint1.position) < 0.1f)
                    {
                        // Réinitialiser les variables une fois que l'araignée est remontée
                        playerDetected = false;
                        isDescending = false;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activer le booléen lorsque le joueur entre dans la zone de détection
            playerDetected = true;
        }
    }
}