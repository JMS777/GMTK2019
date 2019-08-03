using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private CylinderControl cylinderControl;
    private Animator an;
    private Rigidbody2D rb;

    public SpriteRenderer sr;
    public PlayerManager pm;

    // horizontal
    private float horizontal;

    // flags
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        cylinderControl = FindObjectOfType<CylinderControl>();
        an = FindObjectOfType<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Mathf.Clamp(Input.GetAxis("Horizontal"),-1,1);
        //Debug.Log(horizontal);

        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        
        if (horizontal < 0)
        {
            sr.flipX = true;
        }

        //Debug.Log(isMovingLeft);

        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Down");
            an.SetBool("isCharging",true);
        }

        //if (pm.isGrounded && Input.GetButton("Jump") && rb.velocity == Vector2.zero)
        //{
        //    if (Input.GetButtonUp("Jump"))
        //    {
        //        //Debug.Log("Up");

        //    }
        //}
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(-horizontal * Time.deltaTime * 300, 0));

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
