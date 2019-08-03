<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private Rigidbody2D rb;

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
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // movement - horizontal
    private float startMouseY;
    private float mouseX;

    // movement - vertical
    private bool mouseDown;
    private float mouseDownTime;

    // flags
    public bool isRunning;
    public bool isIdle;
    public bool isMovingRight;
    public bool isMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse1 down.");
            mouseDown = true;
            mouseDownTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Mouse1 up.");

            float time = Time.time - mouseDownTime;
            time = Mathf.Clamp(Mathf.Round(time * 2),1,4) / 2;
            //Debug.Log(time);
            float force = time* 300;
            //Debug.Log(force);
            rb.AddForce(new Vector2(0,-force));
            mouseDown = false;
        }
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        if (mouseDown)
        {
            mouseX = Mathf.Clamp(Input.GetAxis("Mouse X"),-1,1);
            
            //Debug.Log(mouseX);
            rb.AddForce(new Vector2(mouseX * Time.deltaTime * 500, 0));
        }
    }
}
>>>>>>> Stashed changes
