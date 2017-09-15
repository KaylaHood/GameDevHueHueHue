using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHue : MonoBehaviour {

    public enum Hue { Red, Blue, Green };
    public Hue hue = Hue.Red;
    public bool isAdditiveHue = true;
    private float hueValue = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Color Consume()
    {
        Color result = new Color(0,0,0);
        if(hue == Hue.Red)
        {
            result.r += (isAdditiveHue) ? hueValue : -hueValue;
        }
        else if (hue == Hue.Green)
        {
            result.g += (isAdditiveHue) ? hueValue : -hueValue;
        }
        else
        {
            result.b += (isAdditiveHue) ? hueValue : -hueValue;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        return result;
    }
}
