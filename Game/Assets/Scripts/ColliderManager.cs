using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Vector2[] vertices;

    public Rigidbody cylinderRigidbody;
    public Transform cylinderTransform;

    // Start is called before the first frame update
    void Start()
    {
        var collider = gameObject.GetComponent<PolygonCollider2D>();
        collider.points = vertices;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float circumference = cylinderTransform.localScale.x * Mathf.PI;

        float rotationsPerSecond = cylinderRigidbody.angularVelocity.y / (2 * Mathf.PI);

        float linearVelocity = circumference / rotationsPerSecond;

        transform.position = new Vector3(linearVelocity * Time.deltaTime, 0, 0);
    }
}
