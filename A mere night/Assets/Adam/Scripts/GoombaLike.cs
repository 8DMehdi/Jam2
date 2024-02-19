using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaLike : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float raycastDistance = 1f;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          // Déplacement vers la gauche si movingRight est vrai, sinon vers la droite
        Vector2 movement = movingRight ? Vector2.left : Vector2.right;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Raycast pour détecter les obstacles devant l'ennemi
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, raycastDistance);

        // Si l'ennemi rencontre un obstacle, changer de direction
        if (hit.collider != null)
        {
            movingRight = !movingRight;
            Flip();
        }
    }
     private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
