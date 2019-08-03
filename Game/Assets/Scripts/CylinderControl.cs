using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public float rpm = 1f;
    public float verticalSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(transform.up, horizontal * (2 * Mathf.PI) * Time.deltaTime * rpm);
        transform.position = new Vector3(transform.position.x, transform.position.y + (verticalSpeed * Time.deltaTime * vertical), transform.position.z);
    }
}
