using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NomDuLieu : MonoBehaviour
{
    public Text lieuText; // Référence au texte à afficher
    public string nomLieu = "BIZEN FOREST"; // Nom du lieu initial
    public float tempsAffichage = 5f; // Temps d'affichage du nom en secondes
    public float tempsFondu = 1f; // Temps de fondu en secondes

    private bool estDansLaZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estDansLaZone = true;
            StartCoroutine(AfficherEtDisparaitre());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estDansLaZone = false;
            lieuText.CrossFadeAlpha(0f, tempsFondu, false); // Disparaître en fondu
        }
    }

    IEnumerator AfficherEtDisparaitre()
    {
        lieuText.text = nomLieu; // Afficher le nom du lieu

        // Fondu d'apparition
        lieuText.CrossFadeAlpha(1f, tempsFondu, false);

        yield return new WaitForSeconds(tempsAffichage);

        if (!estDansLaZone) // Si le joueur n'est plus dans la zone
        {
            // Fondu de disparition
            lieuText.CrossFadeAlpha(0f, tempsFondu, false);
        }
    }
}