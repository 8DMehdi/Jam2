using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlash : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    private Chest chest; // Référence au script Chest

    void Start()
    {
        // Trouvez le coffre dans la scène (assurez-vous qu'il n'y a qu'un seul objet avec le script Chest)
        chest = FindObjectOfType<Chest>();
    }

    void Attack()
    {
        // Vérifiez si le joueur peut attaquer
        if (chest != null && chest.PlayerSlash)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                Debug.Log("It works");
            }
        }
        else
        {
            Debug.Log("Player cannot attack yet.");
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
            Debug.Log("It");
        }
    }
}