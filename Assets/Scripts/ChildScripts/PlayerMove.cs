using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{　　
    /// <summary>横移動のスピード</summary>
    [SerializeField] float speed = 1f;　　　　 
    private Rigidbody2D rb2d = default;
    ///<summary>ジャンプ力の数値</summary>sumary>
    [SerializeField] float m_JumpPower = 1f;
    /// <summary>動きの仕様変更</summary>
    [SerializeField] int mode = 0; 
    private SpriteRenderer spRenderer = default; 
    /// <summary>ジャンプ用の変数</summary>
    int jumpCount = 0;　
　　/// <summary>最大ジャンプ回数</summary>
    [SerializeField] int M_JumpCount = 1;
    float jc = default;
    
    void Start()
    {
        jc = m_JumpPower;
        rb2d = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (mode == 0)
        {
            MoveUsingRigidbodyVelocity();
        }
        else if (mode == 1)
        {
            MoveUsingRigidbodyAddForce();
        }
        else if (mode == 2)
        {
            MoveUsingRigidbodyMovePosition();
        }

    }

    void MoveUsingRigidbodyVelocity()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector2 velo = new Vector2(h, 0).normalized * speed;
        velo.y = rb2d.velocity.y;
        rb2d.velocity = velo;

        if ( velo.x < 0 )
        {
            spRenderer.flipX = true;
        }
        else if (velo.x > 0)
        {
            spRenderer.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < M_JumpCount )
        {
            velo.y = m_JumpPower;
            rb2d.velocity = velo;
            jumpCount++;
        }

    }
    
    void MoveUsingRigidbodyAddForce()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector2 force = new Vector2(h, 0).normalized * speed;
        rb2d.AddForce(force);

        if (force != Vector2.zero)  //向き転換１　入力した瞬間に入力方向に向きが変わる（ex,進行方向が未だ右でも左に入力した瞬間に左を向く）
        {
            this.transform.right = force;    
        } 

        //this.transform.right = rb2d.velocity;　　//向き転換２　速度が変わりきってから逆方向を向く　（ex,左に入力しても速度が左になるまでは右向き）
    }

    void MoveUsingRigidbodyMovePosition()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 pos = new Vector2(h, 0).normalized * speed;
        rb2d.MovePosition(pos + this.transform.position);

        if(pos != Vector3.zero)
        {
            this.transform.right = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            m_JumpPower = jc;
        }

        if(collision.gameObject.tag == "Ground2")
        {
            jumpCount = 0;
            m_JumpPower = 5;
        }
    }
}
