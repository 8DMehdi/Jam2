using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite closedChestSprite; // Sprite fermé
    public Sprite openedChestSprite; // Sprite ouvert
    public bool PlayerSlash = false; // Booléen pour l'attaque

    private SpriteRenderer spriteRenderer;
    private bool isNearChest = false; // Pour vérifier si le joueur est proche
    private bool isOpen = false; // Pour vérifier si le coffre est ouvert

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChestSprite; // Afficher le sprite fermé au début
    }

    void Update()
    {
        // Vérifie si le joueur appuie sur "E" et qu'il est proche du coffre
        if (isNearChest && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        spriteRenderer.sprite = openedChestSprite; // Change le sprite en ouvert
        isOpen = true;
        PlayerSlash = true; // Permet au joueur d'attaquer
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearChest = true; // Le joueur est proche du coffre
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearChest = false; // Le joueur s'éloigne du coffre
        }
    }
}