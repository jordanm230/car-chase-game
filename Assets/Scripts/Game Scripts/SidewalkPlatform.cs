using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewalkPlatform : MonoBehaviour
{
    void Update()
    {
        if (!Car.gameOver && !Car.paused)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            transform.position += new Vector3(0f, -3.5f * Time.deltaTime, 0f);

            if (transform.position.y < -8.45f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Spawner.dim;
        }
    }
}
