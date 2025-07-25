using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MyCar : MonoBehaviour
{
    public static Color stripeColor = Color.white;
    public static Color bodyColor = Color.white;

    public Sprite base0, base1, base2, base3, base4;
    public Sprite detail0, detail1, detail2, detail3, detail4;
    public Sprite stripe0, stripe1, stripe2, stripe3, stripe4;
    public Image previewBase, previewDetail, previewStripe;
    public TMP_Text styleText;
    public Slider rBodySlider, gBodySlider, bBodySlider;
    public Slider rStripeSlider, gStripeSlider, bStripeSlider;
    public Toggle enableStripe;

    private int style;
    private float bodyR, bodyG, bodyB;
    private float stripeR, stripeG, stripeB, stripeA;

    void Start()
    {
        style = PlayerPrefs.GetInt("style", 0);
        bodyR = PlayerPrefs.GetFloat("bodyR", 1f);
        bodyG = PlayerPrefs.GetFloat("bodyG", 1f);
        bodyB = PlayerPrefs.GetFloat("bodyB", 1f);
        stripeR = PlayerPrefs.GetFloat("stripeR", 0f);
        stripeG = PlayerPrefs.GetFloat("stripeG", 0f);
        stripeB = PlayerPrefs.GetFloat("stripeB", 0f);
        stripeA = PlayerPrefs.GetFloat("stripeA", 0f);

        rBodySlider.value = bodyR;
        gBodySlider.value = bodyG;
        bBodySlider.value = bodyB;
        rStripeSlider.value = stripeR;
        gStripeSlider.value = stripeG;
        bStripeSlider.value = stripeB;

        if (stripeA == 1f)
        {
            stripeA = 1f;
            enableStripe.isOn = true;
            PlayerPrefs.SetFloat("stripeA", 1f);
        }
        else
        {
            stripeA = 0f;
            enableStripe.isOn = false;
            PlayerPrefs.SetFloat("stripeA", 0f);
        }

        previewBase.color = new Color(bodyR, bodyG, bodyB);
        previewStripe.color = new Color(stripeR, stripeG, stripeB, stripeA);
    }

    void Update()
    {
        if (enableStripe.isOn)
        {
            stripeA = 1f;
        }
        else
        {
            stripeA = 0f;
        }
        PlayerPrefs.SetFloat("stripeA", stripeA);

        if (style == 0)
        {
            previewBase.sprite = base0;
            previewDetail.sprite = detail0;
            previewStripe.sprite = stripe0;
            styleText.text = "Style 0";
        }
        else if (style == 1)
        {
            previewBase.sprite = base1;
            previewDetail.sprite = detail1;
            previewStripe.sprite = stripe1;
            styleText.text = "Style 1";
        }
        else if (style == 2)
        {
            previewBase.sprite = base2;
            previewDetail.sprite = detail2;
            previewStripe.sprite = stripe2;
            styleText.text = "Style 2";
        }
        else if (style == 3)
        {
            previewBase.sprite = base3;
            previewDetail.sprite = detail3;
            previewStripe.sprite = stripe3;
            styleText.text = "Style 3";
        }
        else if (style == 4)
        {
            previewBase.sprite = base4;
            previewDetail.sprite = detail4;
            previewStripe.sprite = stripe4;
            styleText.text = "Style 4";
        }
        PlayerPrefs.SetInt("style", style);

        bodyColor = new Color(bodyR, bodyG, bodyB);
        previewBase.color = bodyColor;

        stripeColor = new Color(stripeR, stripeG, stripeB, stripeA);
        previewStripe.color = stripeColor;
    }

    public void SwitchCar(string arrow)
    {
        if (arrow == "left")
        {
            if (style == 0)
            {
                style = 4;
            }
            else
            {
                style -= 1;
            }
        }
        else if (arrow == "right")
        {
            if (style == 4)
            {
                style = 0;
            }
            else
            {
                style += 1;
            }
        }
    }

    public void SwitchBodyColor(string colorValue)
    {
        if (colorValue == "r")
        {
            bodyR = rBodySlider.value;
            PlayerPrefs.SetFloat("bodyR", bodyR);
        }
        else if (colorValue == "g")
        {
            bodyG = gBodySlider.value;
            PlayerPrefs.SetFloat("bodyG", bodyG);
        }
        else if (colorValue == "b")
        {
            bodyB = bBodySlider.value;
            PlayerPrefs.SetFloat("bodyB", bodyB);
        }
    }

    public void SwitchStripeColor(string colorValue)
    {
        if (colorValue == "r")
        {
            stripeR = rStripeSlider.value;
            PlayerPrefs.SetFloat("stripeR", stripeR);
        }
        else if (colorValue == "g")
        {
            stripeG = gStripeSlider.value;
            PlayerPrefs.SetFloat("stripeG", stripeG);
        }
        else if (colorValue == "b")
        {
            stripeB = bStripeSlider.value;
            PlayerPrefs.SetFloat("stripeB", stripeB);
        }
    }

    public void Return()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
