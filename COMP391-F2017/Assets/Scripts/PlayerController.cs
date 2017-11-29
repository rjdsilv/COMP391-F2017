using System;
using UnityEngine;

[Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rBody;
    private float shotTimer = 0.0f;

    public float shotDelay = 0.5f;
    public GameObject laser;
    public Transform laserSpawner;

    public float speed = 0.0f;
    // public float xMin, xMax, yMin, yMax;
    public Boundary boundary;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        shotTimer += Time.deltaTime;

		if (Input.GetButton("Laser") && shotTimer > shotDelay)
        {
            Instantiate(laser, laserSpawner.position, laserSpawner.rotation);
            shotTimer = 0;
        }
	}

    // Like update but used with physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Debug.Log("H = " + moveHorizontal + ", V = " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Debug.Log(movement);

        rBody.velocity = movement * speed;
        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, -8.0f, 4.0f), Mathf.Clamp(rBody.position.y, -4.0f, 4.0f));
        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, xMin, xMax), Mathf.Clamp(rBody.position.y, yMin, yMax));
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));
    }
}
