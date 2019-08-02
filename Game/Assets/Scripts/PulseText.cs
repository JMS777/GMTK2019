using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseText : MonoBehaviour
{
    public float pulseTime = 2;
    public float minAlpha = 0.1f;

    private Text text;
    private bool decreasing;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        decreasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = decreasing ? -1 : 1;

        float increment = direction * (Time.deltaTime / (pulseTime / 2));

        float newAlpha = text.color.a + increment;

        if (decreasing && newAlpha <= minAlpha)
        {
            newAlpha = minAlpha;
            decreasing = false;
        }
        else if (!decreasing && newAlpha >= 1)
        {
            newAlpha = 1f;
            decreasing = true;
        }

        var newColor = new Color(text.color.r, text.color.g, text.color.b, newAlpha);
        text.color = newColor;
    }
}
