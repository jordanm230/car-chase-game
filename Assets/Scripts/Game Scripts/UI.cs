using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static float fuelAmount;

    public TMP_Text distanceText;
    public Image fuel; 

    private float t, time;

    void Start()
    {
        t = 0f;
        fuelAmount = 1f;
    }

    void Update()
    {
        if (!Car.gameOver && !Car.paused)
        {
            time += Time.deltaTime;

            if (time >= 1f)
            {
                t += 0.1f;
                time = 0f;
            }

            if (fuelAmount > 1.0f)
            {
                fuelAmount = 1.0f;
            }
            else if (fuelAmount <= 0f)
            {
                Car.gameOver = true;
                return;
            }
            fuelAmount -= Time.deltaTime * 0.025f;

            Car.distance = (float)System.Math.Round(t, 1);
            if (Car.distance > Car.best)
            {
                Car.best = Car.distance;
                PlayerPrefs.SetFloat("distance", Car.best);
            }
            distanceText.text = "" + System.Math.Round(t, 1);
            fuel.fillAmount = fuelAmount;
        }
    }
}
