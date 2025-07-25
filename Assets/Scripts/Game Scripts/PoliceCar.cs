using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public static float speed;

    public Transform player;

    private bool isReturning, backUp;

    void Start()
    {
        isReturning = true;
        backUp = false;
        speed = 0.5f;
    }

    void Update()
    {

        if (!Car.gameOver && !Car.paused)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            if (isReturning && !backUp)
            {
                transform.position += new Vector3(0f, 1f * Time.deltaTime, 0f);

                if (transform.position.y >= -4.9f)
                {
                    if (Car.justStarted == true)
                    {
                        Car.justStarted = false;
                    }
                    isReturning = false;
                    GetComponent<Collider2D>().enabled = true;
                    return;
                }
            }
            else if (backUp && !isReturning)
            {
                transform.position += new Vector3(0f, -2.25f * Time.deltaTime, 0f);

                if (transform.position.y <= -7.25f)
                {
                    backUp = false;
                    isReturning = true;
                }
            }
            else if (!isReturning && !backUp)
            {
                Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Spawner.dim;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            backUp = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
