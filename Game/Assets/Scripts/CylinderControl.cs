using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public Transform colliderTransform;
    public Vector2 imageDimensions;
    public int yOffset;

    [Tooltip("Units Per Pixel")]
    public float scale = 0.01f;

    private Vector3 offset;

    public float RotationFactor
    {
        get
        {
            float circumference = transform.localScale.x * Mathf.PI;

            float distanceTravelled = -colliderTransform.position.x;

            float rotationFactor = distanceTravelled / circumference;

            return rotationFactor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var diameter = imageDimensions.x / Mathf.PI;
        diameter = diameter * scale;
        var height = imageDimensions.y * scale;

        transform.localScale = new Vector3(diameter, height, diameter);

        offset = new Vector3(0.0f, -transform.localScale.y / 2, transform.localScale.z / 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationY = RotationFactor * 360;

        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        transform.position = new Vector3(0.0f, colliderTransform.position.y, colliderTransform.position.z) + offset;
    }
}