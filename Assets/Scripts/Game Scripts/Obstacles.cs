using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void Update()
    {
        if (!Car.gameOver && !Car.paused)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            transform.position += new Vector3(0f, -3.5f * Time.deltaTime, 0f);
            if (transform.position.y < -5.75f)
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
