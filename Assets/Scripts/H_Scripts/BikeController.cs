using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    private Rigidbody2D rb2d = default;
    private SpriteRenderer spRenderer = default;
    Vector3 initialPosition = default;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        initialPosition = this.transform.position;
    }

    void Update()
    {
        float randomSpeed = Random.Range(5F,10F);

        Vector2 velo = new Vector2(h,0).normalized * randomSpeed;
        velo.y = rb2d.velocity.y;
        rb2d.velocity = velo;

        if (velo.x < 0)
        {
            spRenderer.flipX = true;
        }
        else if (velo.x > 0)
        {
            spRenderer.flipX = false;
        }

        if (this.transform.position.y <= -6f)
        {
            this.transform.position = initialPosition;
        }
    }
}
