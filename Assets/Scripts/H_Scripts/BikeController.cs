using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    private Rigidbody2D rb2d = default;
    float randomSpeed = 0;
    [SerializeField] Vector2 m_speedRange;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        randomSpeed = Random.Range(m_speedRange.x, m_speedRange.y);
    }

    void Update()
    {
        Vector2 velo = new Vector2(randomSpeed,0);
        rb2d.velocity = velo;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
