using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperForce = 10f;
    public TarodevController.PlayerController playerController;


    void OnTriggerEnter2D(Collider2D other)
    {   
        playerController._jumpHeight *= 3f;
        
    }
    void OnTriggerExit2D(Collider2D other)
        {
            playerController._jumpHeight /= 3f;
        }
}
