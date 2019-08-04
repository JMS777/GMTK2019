using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    void FixedUpdate()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        cl.OverlapCollider(new ContactFilter2D(), colliders);

        if (colliders.Exists(p => p.tag == "Environment"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}