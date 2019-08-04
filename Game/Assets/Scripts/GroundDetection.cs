using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private Collider2D cl;
    public Collider2D world;

    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        cl = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cl.IsTouching(world))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}