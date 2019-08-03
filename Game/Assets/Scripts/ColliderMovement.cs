using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private CylinderControl cylinderControl;

    private float startMouseY;
    private bool mouseDown;

    // flags
    public bool isRunning;
    public bool isIdle;
    public bool isMovingRight;
    public bool isMovingLeft;

    // collision
    public bool isRising;
    public bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cylinderControl = FindObjectOfType<CylinderControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse1 down.");
            mouseDown = true;
            startMouseY = Input.mousePosition.y;
            //Debug.Log(startMouseY);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Mouse1 up.");
            float endMouseY = Input.mousePosition.y;
            //Debug.Log(endMouseY);
            float force = startMouseY - endMouseY;
            //Debug.Log(force);
            if (force == Mathf.Abs(force))
            {
                rb.AddForce(new Vector2(0,force*-2));
            }
            mouseDown = false;
        }
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        if (mouseDown)
        {
            //Debug.Log("this");
            float mouseX = Input.GetAxis("Mouse X");
            rb.AddForce(new Vector2(mouseX * Time.deltaTime * 200, 0));
        }

        if (cylinderControl.RotationFactor < 0)
        {
            transform.position = new Vector3(-cylinderControl.imageDimensions.x * cylinderControl.scale, transform.position.y, transform.position.z);
        }
        else if (cylinderControl.RotationFactor >= 1)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);

        }
    }
}
