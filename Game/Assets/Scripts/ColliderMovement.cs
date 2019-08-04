using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private CylinderControl cylinderControl;
    private Animator an;
    private Rigidbody2D rb;

    private float speed;
    private float accelStartTime;
    private float jumpStartTime;

    public float maxHVelocity = 5;
    public float terminalVelocity = 2;

    public AnimationCurve acceleration;
    public AnimationCurve deceleration;
    public AnimationCurve jumpPower;

    public SpriteRenderer sr;

    private GroundDetection gd;

    private bool jumpStarted = false;

    // horizontal
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        cylinderControl = FindObjectOfType<CylinderControl>();
        an = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gd = FindObjectOfType<GroundDetection>();

        an.SetBool("isCharging", false);
        an.SetBool("isJumping", false);
        an.SetBool("isRunning", false);
        an.SetBool("isGliding", false);
        an.SetBool("isIdle", false);
        an.SetBool("isEnd", false);
        an.SetBool("isDead", false);

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.isKinematic)
        {
            if (!an.GetBool("isCharging"))
            {
                HandleHorizontalMovement();
            }
                
            HandleJump();

            rb.velocity = new Vector2(rb.velocity.x, Mathf.Min(rb.velocity.y, terminalVelocity));

            if ((an.GetBool("isJumping") && rb.velocity.y > 0) || (an.GetBool("isRunning") && !gd.isGrounded))
            {
                an.SetBool("isJumping", false);
                an.SetBool("isGliding", true);
            }

            if (an.GetBool("isGliding") && gd.isGrounded)
            {
                an.SetBool("isGliding", false);
                an.SetBool("isIdle", true);
            }

            if (rb.velocity == Vector2.zero)
            {
                an.SetBool("isIdle", true);
            }
        }

        //Debug.Log(go.isGrounded);
    }

    private void HandleHorizontalMovement()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            accelStartTime = Time.time;
        }

        float timeSinceAccel = Time.time - accelStartTime;

        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = false;

            if (gd.isGrounded & !Input.GetButton("Jump"))
            {
                an.SetBool("isIdle", false);
                an.SetBool("isRunning", true);
            }

            if (speed > 0)
            {
                speed = deceleration.Evaluate(timeSinceAccel) * maxHVelocity;

                if (speed == 0)
                {
                    accelStartTime = Time.time;
                }
            }
            else if (speed <= 0)
            {
                speed = -acceleration.Evaluate(timeSinceAccel) * maxHVelocity;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = true;


            if (gd.isGrounded & !Input.GetButton("Jump"))
            {
                an.SetBool("isIdle", false);
                an.SetBool("isRunning", true);
            }

            if (speed >= 0)
            {
                speed = acceleration.Evaluate(timeSinceAccel) * maxHVelocity;
            }
            else if (speed < 0)
            {
                speed = -deceleration.Evaluate(timeSinceAccel) * maxHVelocity;

                if (speed == 0)
                {
                    accelStartTime = Time.time;
                }
            }
        }
        else
        {
            an.SetBool("isRunning", false);

            if (speed > 0)
            {
                speed = deceleration.Evaluate(timeSinceAccel) * maxHVelocity;
            }
            else if (speed < 0)
            {
                speed = -deceleration.Evaluate(timeSinceAccel) * maxHVelocity;
            }
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (gd.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpStarted = true;
                an.SetBool("isCharging", true);
                jumpStartTime = Time.time;
            }

            if (jumpStarted && Input.GetButtonUp("Jump"))
            {
                an.SetBool("isIdle", false);
                an.SetBool("isJumping", true);
                an.SetBool("isCharging", false);

                jumpStarted = false;

                rb.velocity = new Vector2(rb.velocity.x, -jumpPower.Evaluate(Time.time - jumpStartTime));
            }
        }
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        // Moves the collider back to the other side when the cylinder rotates 360.
        if (cylinderControl.RotationFactor < 0)
        {
            transform.position = new Vector3(-cylinderControl.imageDimensions.x * cylinderControl.scale, transform.position.y, transform.position.z);
        }
        else if (cylinderControl.RotationFactor >= 1)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    public void DisableIsKinematic()
    {
        rb.isKinematic = false;
    }

    public void EnableIsKinematic()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
}
