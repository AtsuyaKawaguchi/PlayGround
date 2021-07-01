using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeGenerate : MonoBehaviour
{
    [SerializeField] GameObject m_BikePrehub;
    [SerializeField, Range(0, 10)] public int m_BikeLimit;
    [SerializeField] AudioClip m_audioClip;

    void Update()
    {
        //int bikeCount = this.GetComponentsInChildren<BikeController>().Length;
        int bikeCount = GameObject.FindGameObjectsWithTag("Bike").Length;

        if (m_BikeLimit == 0 || bikeCount < m_BikeLimit)
        {
            var go = Instantiate(m_BikePrehub, this.transform.position, m_BikePrehub.transform.rotation);
            //go.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = GameObject.Find("H_GameManager");
            H_GameManager dm  = go.GetComponent<H_GameManager>();
            dm.LoseHp(1);
            Destroy(this.gameObject);
            
        }
    }
}
