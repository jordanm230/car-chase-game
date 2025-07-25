using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Color original;

    private bool backUp = false;

    void Start()
    {
        int rand = Random.Range(0, 5);

        if (rand == 0)
        {
            original = new Color(0.3333333f, 0.3176471f, 0.3176471f);
        }
        else if (rand == 1)
        {
            original = new Color(0.5568628f, 0.04705882f, 0.04705882f);
        }
        else if (rand == 2)
        {
            original = new Color(0.0627451f, 0.08235294f, 0.4431373f);
        }
        else if (rand == 3)
        {
            original = new Color(0.1607843f, 0.3490196f, 0.1490196f);
        }
        else if (rand == 4)
        {
            original = new Color(0.1607843f, 0.1607843f, 0.1607843f);
        }

        GetComponent<SpriteRenderer>().color = original;
    }

    void Update()
    {
        if (!Car.gameOver && !Car.paused)
        {
            GetComponent<SpriteRenderer>().color = new Color(original.r, original.g, original.b, 1f);

            if (backUp)
            {
                transform.position += new Vector3(0f, -4f * Time.deltaTime, 0f);
            }
            else 
            {
                transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);
            }

            if (transform.position.y < -6.15f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(original.r, original.g, original.b, 0.6509804f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Gas"))
            {
                Destroy(collision.gameObject);
            }
            else
            {
                backUp = true;
            }
        }
    }
}
