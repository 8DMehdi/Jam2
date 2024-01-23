using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouge : MonoBehaviour
{
    public float vitesseDeplacement = 5f;

    void Update()
    {
        // Obtenez la position actuelle de l'objet
        Vector3 position = transform.position;

        // Calculez la nouvelle position vers la gauche
        position.x -= vitesseDeplacement * Time.deltaTime;

        // Appliquez la nouvelle position à l'objet
        transform.position = position;
    }
}