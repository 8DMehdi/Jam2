using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mooveSkelete : MonoBehaviour
{
    public float moveSpeed = 1f; // Vitesse de déplacement du sprite

    void Update()
    {
        // Déplacement vers la gauche
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Rotation du sprite vers la gauche (optionnel)
        // Vous pouvez ajuster l'angle de rotation en fonction de vos besoins
        transform.rotation = Quaternion.Euler(0, 180, 0); // Rotation de 180 degrés sur l'axe Y (pour tourner vers la gauche)

        // Si vous voulez que le sprite avance dans sa propre direction de rotation, utilisez plutôt :
        // transform.Translate(transform.right * moveSpeed * Time.deltaTime);
    }
}
