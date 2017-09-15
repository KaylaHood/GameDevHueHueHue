using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueConsumer : MonoBehaviour {

    private SpriteRenderer spR;

	// Use this for initialization
	void Start () {
        spR = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ConsumeColorBlob(ConsumableHue colorBlob)
    {
        spR.color += colorBlob.Consume();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("ColorBlob"))
        {
            ConsumeColorBlob(other.gameObject.GetComponent<ConsumableHue>());
        }
    }
}
