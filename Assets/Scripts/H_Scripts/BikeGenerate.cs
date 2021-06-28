using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeGenerate : MonoBehaviour
{
    [SerializeField] GameObject m_BikePrehub;
    [SerializeField, Range(0, 10)] public int m_BikeLimit;

    void Start()
    {
        //Instantiate(m_BikePrehub, this.transform.position, m_BikePrehub.transform.rotation);
    }

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
}
