using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodymove : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Rigidbody2D rb = default;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //Vector2 sp = new Vector2(h, 0).normalized * speed;
        //rb.AddForce(sp);
        rb.AddForce(Vector2.right * h * speed);
        this.transform.right = rb.velocity;

        anim.SetFloat("Speed", speed);
    }


}
