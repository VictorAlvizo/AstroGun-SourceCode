using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;

    public GameObject walkingParticle;

    private bool facingRight = true;

    private float lastSpawnParticle = 0.0f;

    private Rigidbody2D rb;

    private Animator animate;

	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }
	
	void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horzMove);
    }

    void MoveCharacter(float horzValue)
    {
        if(horzValue == 0)
        {
            rb.velocity = Vector2.zero;
            animate.SetBool("isWalking", false);
        }
        else
        {
            rb.velocity = new Vector2(horzValue * speed, transform.position.y);
            animate.SetBool("isWalking", true);

            if(horzValue == 1 && !facingRight)
            {
                animate.transform.Rotate(180, 0, 180);
                facingRight = true;
            }else if(horzValue == -1 && facingRight)
            {
                animate.transform.Rotate(180, 0, -180);
                facingRight = false;
            }

            if(Time.time > lastSpawnParticle + 0.1f)
            {
                Transform spawnTrail = transform.Find("FeetHolder");

                Instantiate(walkingParticle, spawnTrail.position, Quaternion.identity);

                lastSpawnParticle = Time.time;
            }
        }
    }
}
