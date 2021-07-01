using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] AudioClip m_audio = default;
 
    void Update()
    {
        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Player")
         {
             GameObject go = GameObject.Find("H_GameManager");
             H_GameManager dm = go.GetComponent<H_GameManager>();
             dm.LoseHp(1);
             Destroy(this.gameObject);
             AudioSource.PlayClipAtPoint(m_audio, this.transform.position);
             //Instantiate(effect, this.transform.position, this.transform.rotation);
         }


     }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = GameObject.Find("H_GameManager");
            H_GameManager sc = go.GetComponent<H_GameManager>();
            sc.LoseScore(1);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(m_audio, this.transform.position);
            //Instantiate(effect, this.transform.position, this.transform.rotation);
        }
    }
}
