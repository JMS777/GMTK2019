using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CameraShake cameraShake;

    public ColliderMovement col;

    public bool isGrounded;
    public float GroundThreshold = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
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
        //Debug.Log(isGrounded);
    }

    public void ChargeShake()
    {
        cameraShake.Shake(ShakeIntensity.Charge);
    }

    public void DisableLevelKinematic()
    {
        col.DisableIsKinematic();
    }
}
