using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public GameObject[] items;

    private Vector3 roadStart = new Vector3(0f, 9.45f, 0f);
    private Vector3 itemStart = new Vector3(7f, 5.85f, 0f);
    private bool spawned;
    private float nextItem;

    void Start()
    {
        nextItem = 10f;
    }

    void Update()
    {

        if (!Car.gameOver && !Car.paused)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            nextItem -= Time.deltaTime;

            if (nextItem <= 0f)
            {
                int rand = Random.Range(0, 3);
                Instantiate(items[rand], itemStart, Quaternion.identity);
                nextItem = Random.Range(10f, 15f);
            }

            transform.position += new Vector3(0f, -3.5f * Time.deltaTime, 0f);

            if (transform.position.y <= 0f)
            {
                if (!spawned)
                {
                    Spawner.Road(road, roadStart);
                    spawned = true;
                }

                if (transform.position.y < -10f)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Spawner.dim;
        }
    }
}
