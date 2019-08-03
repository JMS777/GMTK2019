using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            cameraShake.Shake(ShakeIntensity.Landing);
            var contacts = new List<ContactPoint2D>();
            var n = collision.GetContacts(contacts);

            foreach(var contact in contacts)
            {
                Debug.Log(contact);
            }
        }
    }
}
