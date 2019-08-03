using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public Transform colliderTransform;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.0f, - transform.localScale.y / 2, transform.localScale.z / 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float circumference = transform.localScale.x * Mathf.PI;

        float distanceTravelled = -colliderTransform.position.x;

        float rotationFactor = distanceTravelled / circumference;

        float rotationY = rotationFactor * 360;

        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        transform.position = new Vector3(0.0f, colliderTransform.position.y, colliderTransform.position.z) + offset;
    }
}
