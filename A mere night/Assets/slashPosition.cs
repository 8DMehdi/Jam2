using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashPosition : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // Move to the right position
            transform.position = new Vector3(1.4f, 0.8f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Move to the left position
            //transform.position = new Vector3(-1.4f, 0.8f, 0f);
        }
    }
}