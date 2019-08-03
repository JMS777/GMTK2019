using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody rb;

    ////
    private bool mouseDragging = false;

    ////
    private Vector3 rigidBodyOriginalPositon;

    ////
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 cursorScreenPoint;
    private Vector3 cursorPosition;

    ////
    private float mousex;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyOriginalPositon = rb.position + new Vector3(0,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }

    void FixedUpdate()
    {
        if (!mouseDragging)
        {
            //rb.AddForce(((rigidBodyOriginalPositon - rb.position) * 20 - rb.velocity) * rb.mass * Time.deltaTime); // attempt 1
            rb.AddForce((rigidBodyOriginalPositon - rb.position).normalized * Time.deltaTime * 25); // attempt 2
        }
        else
        {
            rb.AddForce(-(rb.position - cursorPosition));
            rb.AddTorque(new Vector3(0, 150, 0) * Time.deltaTime * -mousex);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse1 down.");

        mouseDragging = true;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse1 up.");

        mouseDragging = false;
    }

    void OnMouseDrag()
    {
        Debug.Log("Dragging.");

        cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        mousex = Input.GetAxis("Mouse X");
    }
}


// add force to get to position. 

// clamp speed through velocity on rb

// when don't click, return with slowly greater force

// when within small distance of destination, set vel 0, move to original position