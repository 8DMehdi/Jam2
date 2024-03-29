using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>();
    public bool isPlayerNearby = false;
    public animation scriptPabloReference;
   
    // Define the action button (you can customize this in the Unity Input Manager)
     void Start()
    {
        // Get a reference to the 'animation' script
        
    }

    private void Update()
   {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby == true)
            {
                
                OpenChest();
                
            }
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        
        
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // You might want to show a UI prompt here (e.g., "Press E to Open")
            isPlayerNearby = true;
            // Check for player input to open the chest
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            // Reset the flag when the player exits the trigger zone
            isPlayerNearby = false;

            // You might want to hide the UI prompt here
        }
    }

    private void OpenChest()
    {
        scriptPabloReference.SlashUnlock = true; 
        // Apply upgrades when the chest is opened
        ApplyUpgrades();
        // You might also want to add visual effects, sound, or other gameplay elements here
    }

    private void ApplyUpgrades()
    {
        
        
        gameObject.SetActive(false);
        foreach (Upgrade upgrade in upgrades)
        {
            // Apply the upgrade to the player or relevant game element
            // For example, you might have a Player class with an ApplyUpgrade method
            chestSytemPlayer.ApplyUpgrade(upgrade);
        }
    }
}