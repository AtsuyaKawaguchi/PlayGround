using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Generator : MonoBehaviour
{
    [Header("Object creation")]
    [SerializeField] GameObject prefabToSpawn;

    [Header("Other Options")]
    [SerializeField] public float spawnInterval = 1;

    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            float randomX = Random.Range(-boxCollider2D.size.x, boxCollider2D.size.x) * .5f;
            //float randomX = Random.Range(-boxCollider2D.size.x, boxCollider2D.size.x);　こちらだと時々枠の外にスポーンされる
            //float randomY = Random.Range(-boxCollider2D.size.y, boxCollider2D.size.y) * .5f;  Y軸は固定したいためランダムにする必要がない

            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = new Vector2(randomX + this.transform.position.x ,this.transform.position.y - 1f);

            yield return new WaitForSeconds(spawnInterval);

        }
    }

}