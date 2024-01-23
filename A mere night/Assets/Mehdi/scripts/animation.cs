using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator animator;
    public bool SlashUnlock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetMyBoolVariable(bool newValue)
    {
        SlashUnlock = newValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && SlashUnlock == true)
        {
            animator.SetTrigger("Attack");

        }
    }
}
