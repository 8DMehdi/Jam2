using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Vitesse de deplacement de l'ennemi
    private Vector3 direction = Vector3.left; // Direction initiale de l'ennemi (vers la droite)
    private float distanceTraveled = 0f; // Distance parcourue par l'ennemi dans sa direction actuelle

    void Update()
    {
        // Deplacer l'ennemi dans sa direction actuelle a la vitesse specifiee
        transform.Translate(direction * speed * Time.deltaTime);

        // Ajouter la distance parcourue dans cette frame a la distance totale parcourue
        distanceTraveled += speed * Time.deltaTime;

        // Si la distance parcourue depasse 3 unites Unity
        if (distanceTraveled >= 10f)
        {
            // Inverser la direction de l'ennemi
            direction *= -1;

            // Reinitialiser la distance parcourue a 0
            distanceTraveled = 0f;
        }
    }
}