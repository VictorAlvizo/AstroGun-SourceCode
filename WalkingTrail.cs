using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTrail : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Start () {
        rb.velocity = Vector2.up * speed;

        Destroy(gameObject, 0.3f);
	}
}
