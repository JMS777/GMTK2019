using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;

    public GameObject pl;
    private SpriteRenderer sr;

    // horizontal
    private float horizontal;

    // vertical
    private float keyDownTime;

    // flags
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = pl.GetComponent<SpriteRenderer>();
        an = gameObject.GetComponent<Animator>();
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
            keyDownTime = Time.time;
        }

        if (Input.GetButtonUp("Jump"))
        {
            //Debug.Log("Up");
            float time = Mathf.Clamp(Mathf.Round((Time.time-keyDownTime) * 2), 1, 4)/2;
            //Debug.Log(time);
            rb.AddForce(new Vector2(0,time*-250));
        }
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(-horizontal * Time.deltaTime * 300, 0));
    }
}
