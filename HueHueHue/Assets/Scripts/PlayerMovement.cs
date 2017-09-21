
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float movementSpeed = 600;
    public float jumpVelocity = 600;
    private bool isGrounded = false;
    private GameObject playerCamera;
    private Vector3 newCamPos;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCamera = GameObject.Find("Camera");
        newCamPos = playerCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        if(horizontalMovement >= 0.01f || horizontalMovement <= 0.01f)
        {
            // Debug print
            //Debug.Log("horizontal movement: " + horizontalMovement);
            rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
            Debug.Log("velocity: " + rb.velocity);
        }
        if(verticalMovement >= 0.01f && isGrounded)
        {
            // Debug print
            Debug.Log("vertical movement: " + verticalMovement);
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
        }
        newCamPos = new Vector3(transform.position.x, newCamPos.y, newCamPos.z);
        playerCamera.transform.position = Vector3.LerpUnclamped(playerCamera.transform.position, newCamPos, Time.deltaTime * 1.5f);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            newCamPos = new Vector3(playerCamera.transform.position.x, transform.position.y, playerCamera.transform.position.z);
        }
    }
}
