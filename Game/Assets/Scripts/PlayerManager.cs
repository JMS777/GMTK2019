using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CameraShake cameraShake;
    private GameManager gameManager;

    public ColliderMovement col;
    private Transform portalTransform;

    public float portalThreshold = 0.1f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        portalTransform = GameObject.FindGameObjectWithTag("Portal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, new Vector2(0,-1), hits);
        //Debug.Log(hits[1]);
        float distance = Vector2.Distance(transform.position, hits[1].point);
        //Debug.Log(distance);
        if (distance < 0.7)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        CheckDistanceToPortal();
        //Debug.Log(isGrounded);
    }

    private void CheckDistanceToPortal()
    {
        float distanceToPortal = Vector3.Distance(transform.position, portalTransform.position);

        if (distanceToPortal < portalThreshold)
        {
            // Play animation
            gameManager.LevelComplete();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            cameraShake.Shake(ShakeIntensity.Landing);
        }
    }

    public void IncreaseJumpPower()
    {
        col.IncreaseJumpPower();   
    }
}
