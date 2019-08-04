using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CameraShake cameraShake;

    public ColliderMovement col;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
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
