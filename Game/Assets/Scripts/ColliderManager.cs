using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Vector2[] vertices;

    public Rigidbody cylinderRigidbody;
    public Transform cylinderTransform;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        var collider = gameObject.GetComponent<EdgeCollider2D>();
        collider.points = vertices;

        offset = new Vector3(0.0f, cylinderTransform.localScale.y / 2, -cylinderTransform.localScale.z / 2);

        transform.position = offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float circumference = cylinderTransform.localScale.x * Mathf.PI;
        float rotationFactor = cylinderTransform.rotation.eulerAngles.y / 360;

        float distanceTravelled = rotationFactor * circumference;

        transform.position = new Vector3(cylinderTransform.position.x - distanceTravelled, cylinderTransform.position.y, cylinderTransform.position.z) + offset;
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
        Debug.Log("Collided with environment");
        if (collision.gameObject.tag == "Environment")
        {
            Debug.Log("Collided with environment");
        }
    }
}
