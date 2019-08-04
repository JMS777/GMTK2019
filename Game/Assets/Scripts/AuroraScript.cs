using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraScript : MonoBehaviour
{
    public float scale = 0.05f;
    public Transform LevelTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 10 + (LevelTransform.position.y * scale), transform.position.z);
    }
}
