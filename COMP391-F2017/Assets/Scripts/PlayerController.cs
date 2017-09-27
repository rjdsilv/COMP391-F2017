using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Like update but used with physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Debug.Log("H = " + moveHorizontal + ", V = " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Debug.Log(movement);

        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }
}
