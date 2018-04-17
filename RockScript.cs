using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RockScript : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private Animator animate;

	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }

    void OnEnable()
    {
        rb.velocity = Vector2.down * speed;
    }

    void OnDisable()
    {
        CancelInvoke();

        animate.SetBool("metCollider", false);
    }

    void DestroyRock()
    {
        gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            rb.velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;

            animate.SetBool("metCollider", true);

            AudioManager.Instance.PlaySound("RockCrash");

            if (PauseMenu.shakeCam)
            {
                CameraShaker.Instance.ShakeOnce(2f, 3f, .1f, .5f);
            }

            Invoke("DestroyRock", 0.5f);
        }

        if(col.tag == "Player")
        {
            animate.SetBool("metCollider", true);

            AudioManager.Instance.PlaySound("PlayerDead");

            Destroy(col.gameObject);
            Invoke("DestroyRock", 0.5f);

            GameControl.instance.Death();
        }
    }
}
