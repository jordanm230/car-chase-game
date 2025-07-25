using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Car : MonoBehaviour
{
    public static bool justStarted, gameOver, paused;
    public static float distance, best;

    public GameObject car0, car1, car2, car3, car4;
    public GameObject stripe0, stripe1, stripe2, stripe3, stripe4;
    public Rigidbody2D rb;
    public GameObject pausePanel, gameOverPanel, instructionsPanel, UIPanel;
    public TMP_Text distanceScore, bestScore;

    private int style;
    private float bodyR, bodyG, bodyB;
    private float stripeR, stripeG, stripeB, stripeA;
    private Color bodyColor, stripeColor;
    private Vector3 playerStart = new Vector3(7.4f, 3.25f, 0f);

    void Start()
    {
        best = PlayerPrefs.GetFloat("distance", 0);

        gameOver = false;
        paused = false;
        UIPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);

        style = PlayerPrefs.GetInt("style", 0);
        bodyR = PlayerPrefs.GetFloat("bodyR", 1f);
        bodyG = PlayerPrefs.GetFloat("bodyG", 1f);
        bodyB = PlayerPrefs.GetFloat("bodyB", 1f);
        stripeR = PlayerPrefs.GetFloat("stripeR", 0f);
        stripeG = PlayerPrefs.GetFloat("stripeG", 0f);
        stripeB = PlayerPrefs.GetFloat("stripeB", 0f);
        stripeA = PlayerPrefs.GetFloat("stripeA", 0f);

        bodyColor = new Color(bodyR, bodyG, bodyB);
        stripeColor = new Color(stripeR, stripeG, stripeB, stripeA);

        if (style == 0)
        {
            car0.SetActive(true);
            car0.GetComponent<SpriteRenderer>().color = bodyColor;
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);

            stripe0.SetActive(true);
            stripe0.GetComponent<SpriteRenderer>().color = stripeColor;
            stripe1.SetActive(false);
            stripe2.SetActive(false);
            stripe3.SetActive(false);
            stripe4.SetActive(false);
        }
        else if (style == 1)
        {
            car0.SetActive(false);
            car1.SetActive(true);
            car1.GetComponent<SpriteRenderer>().color = bodyColor;
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);

            stripe0.SetActive(false);
            stripe1.SetActive(true);
            stripe1.GetComponent<SpriteRenderer>().color = stripeColor;
            stripe2.SetActive(false);
            stripe3.SetActive(false);
            stripe4.SetActive(false);
        }
        else if (style == 2)
        {
            car0.SetActive(false);
            car1.SetActive(false);
            car2.SetActive(true);
            car2.GetComponent<SpriteRenderer>().color = bodyColor;
            car3.SetActive(false);
            car4.SetActive(false);

            stripe0.SetActive(false);
            stripe1.SetActive(false);
            stripe2.SetActive(true);
            stripe2.GetComponent<SpriteRenderer>().color = stripeColor;
            stripe3.SetActive(false);
            stripe4.SetActive(false);
        }
        else if (style == 3)
        {
            car0.SetActive(false);
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(true);
            car3.GetComponent<SpriteRenderer>().color = bodyColor;
            car4.SetActive(false);

            stripe0.SetActive(false);
            stripe1.SetActive(false);
            stripe2.SetActive(false);
            stripe3.SetActive(true);
            stripe3.GetComponent<SpriteRenderer>().color = stripeColor;
            stripe4.SetActive(false);
        }
        else if (style == 4)
        {
            car0.SetActive(false);
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(true);
            car4.GetComponent<SpriteRenderer>().color = bodyColor;

            stripe0.SetActive(false);
            stripe1.SetActive(false);
            stripe2.SetActive(false);
            stripe3.SetActive(false);
            stripe4.SetActive(true);
            stripe4.GetComponent<SpriteRenderer>().color = stripeColor;
        }

        transform.position = playerStart;
        justStarted = true;
    }

    void Update()
    {
        if (gameOver)
        {
            rb.Sleep();
            UIPanel.SetActive(false);
            gameOverPanel.SetActive(true);

            distanceScore.text = "" + distance;
            bestScore.text = "" + best;
        }
        else if (paused)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                rb.WakeUp();
                paused = false;
                pausePanel.SetActive(false);
                instructionsPanel.SetActive(false);
            }
        }
        else if (!gameOver && !paused)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                rb.Sleep();
                paused = true;
                pausePanel.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!gameOver && !justStarted && !paused)
        {
            float hmove = Input.GetAxisRaw("Horizontal");

            if (hmove > 0 && transform.position.x < 9.75f)
            {
                rb.AddForce(new Vector2(hmove, 0) * 10f);
            }

            else if (hmove < 0 && transform.position.x > 1.5f)
            {
                rb.AddForce(new Vector2(hmove, 0) * 10f);
            }

            else
            {
                if (Mathf.Abs(rb.velocity.x) > 0)
                {
                    rb.AddForce(new Vector2(-rb.velocity.x, 0) * 18f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gas"))
        {
            UI.fuelAmount += 0.2f;
            Destroy(collision.gameObject);
        }
        else if (!collision.gameObject.CompareTag("Gas") && !collision.gameObject.CompareTag("Police"))
        { 
            Destroy(collision.gameObject);
            gameOver = true;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Instructions()
    {
        pausePanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void Return()
    {
        instructionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
