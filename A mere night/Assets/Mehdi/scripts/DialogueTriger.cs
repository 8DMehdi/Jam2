using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{ 
    public Dialogue dialogue;
    public bool isPlayerNearby = false;
    private DialogueManager dialogueManager;
    public GameObject UIe;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void Update()
   {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby == true)
            {
                Debug.Log("hey");
                dialogueManager.StartDialogue(dialogue);
                
            }
            
        if (Input.GetKeyDown(KeyCode.Return) && isPlayerNearby == true)
            {
                dialogueManager.DisplayNextSentences();
            }
            
   }

     private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        UIe.SetActive(true);
        
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
        UIe.SetActive(false);
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            // Reset the flag when the player exits the trigger zone
            isPlayerNearby = false;

            // You might want to hide the UI prompt here
        }
    }

}
