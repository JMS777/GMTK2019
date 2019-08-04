using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCollision : MonoBehaviour
{
    private Collider2D[] cls;

    public Collider2D world;
    public Animator an;
    
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        cls = gameObject.GetComponents<Collider2D>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // either left or right horizontal collider touches world collider
        if (cls[0].IsTouching(world) || cls[1].IsTouching(world))
        {
            an.SetBool("isDead", true);
            gm.GameOver();
        }
    }
}
