using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Transform cylinderTransform;

    public float shakeThreshold = 2;

    public EdgeCollider2D[] colliders;
    public string[] colliderFilenames;

    private Vector3 offset;


    private CameraShake cameraShake;

    private Rigidbody2D colliderRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        colliderRigidbody = gameObject.GetComponent<Rigidbody2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            string[] pointStrings = File.ReadAllLines(getPath() + "/Meshes/" + colliderFilenames[i]);

            var points = new List<Vector2>();

            foreach (var pointString in pointStrings)
            {
                string[] coordinates = pointString.Split(',');

                if (coordinates.Length > 1)
                {
                    var vertex = new Vector2(float.Parse(coordinates[0]), float.Parse(coordinates[1]));

                    points.Add(vertex);
                }
            }

            colliders[i].points = points.ToArray();
        }
    }

    // Get path for given CSV file
    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath;
#elif UNITY_ANDROID
return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
return Application.dataPath;// +"/"+ fileName;
#endif
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (colliderRigidbody.velocity.y >= -shakeThreshold)
            {
                cameraShake.Shake(ShakeIntensity.Landing);
            }
        }
    }
}
