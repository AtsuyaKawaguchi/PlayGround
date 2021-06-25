using UnityEngine;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    //[SerializeField] Vector3 b_offset = default;
    public int JumpCount = 0;
    //public Rigidbody2D rb;
    [SerializeField] int M_JumpCount = 2;






    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        // 各種入力を受け取る
        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {
            Debug.Log(JumpCount);
            JumpCount--;
            m_rb.AddForce(Vector2.up.normalized * m_jumpPower, ForceMode2D.Impulse);

        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }


        /// <summary>
        /// 左右を反転させる
        /// </summary>
        /// <param name="horizontal">水平方向の入力値</param>
        void FlipX(float horizontal)
        {
            /*
             * 左を入力されたらキャラクターを左に向ける。
             * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
             * Sprite Renderer の Flip:X を操作しても反転する。
             * */
            m_scaleX = this.transform.localScale.x;

            if (horizontal > 0)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
            else if (horizontal < 0)
            {
                this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        }
    }
    void FixedUpdate()
    {
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpCount = 2;
        }
    }

}
