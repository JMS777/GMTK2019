using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCollision : MonoBehaviour
{
    private Collider2D[] cls;

    public Collider2D world;
    public Animator an;
    
    private GameManager gm;

    public Transform tf;
    public SpriteRenderer sr;

    bool canDieOnLeft;
    bool canDieOnRight;

    Rigidbody2D worldrb;

    // Start is called before the first frame update
    void Start()
    {
        cls = gameObject.GetComponents<Collider2D>();
        Debug.Log(cls.Length);
        gm = FindObjectOfType<GameManager>();

        worldrb = world.attachedRigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = worldrb.velocity;

        canDieOnLeft = vel.x < 0;
        canDieOnRight = vel.x > 0;

        // either left or right horizontal collider touches world collider
        if (!an.GetBool("isDead") && cls[0].IsTouching(world) && canDieOnRight)
        {
            tf.localScale = new Vector3(-tf.localScale.x,tf.localScale.y,tf.localScale.z);
            sr.flipX = false;
            an.SetBool("isDead", true);
            gm.GameOver();
        }

        if (!an.GetBool("isDead") && cls[1].IsTouching(world) && canDieOnLeft)
        {
            an.SetBool("isDead", true);
            gm.GameOver();
        }
    }
}
