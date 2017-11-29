using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rBody;

    public float speed = 20f;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
	}
}
