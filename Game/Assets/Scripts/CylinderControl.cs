using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public float rotationalSpeed = 1f;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddTorque(new Vector3(0, 3, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
