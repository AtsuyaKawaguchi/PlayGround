using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkController : MonoBehaviour
{
    [SerializeField] AudioClip m_audio = default;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = GameObject.Find("GameManager");
            GameManager gm = go.GetComponent<GameManager>();
            gm.LoseScore(1);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(m_audio, this.transform.position);
        }
        
    }
}
