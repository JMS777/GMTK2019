using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with environment");
        if (collision.gameObject.tag == "Environment")
        {
            Debug.Log("Collided with environment");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player: Collided with environment");
        if (collision.gameObject.tag == "Environment")
        {
            Debug.Log("Player 2: Collided with environment");
        }
    }
}
