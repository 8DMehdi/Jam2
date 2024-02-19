using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int SetMaxHealth;
    public int currentHealth;
    public int damage; 

    void Start()
    {
        currentHealth = SetMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);

        }
          if (Input.GetKeyDown("space"))
        {
            //TakeDamage(damage);
            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D Collision){
        if (Collision.gameObject.tag == "bullet")
        {
            TakeDamage(damage);


        }
        
    }
}
