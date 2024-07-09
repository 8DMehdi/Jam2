using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Health healthScript;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthScript.health--;
            if (healthScript.health < 0)
            {
                healthScript.health = 0;
            }
        }
    }
}
