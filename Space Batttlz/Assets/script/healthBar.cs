using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private static SpriteRenderer HealthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<SpriteRenderer>();
        // playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
    }


    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.size = new Vector2(value / 10 , 1);
        if(value < 20f)
        {
            SetHealthBarColor(Color.red);
        }
        else if(value < 40f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    // public static float GetHealthBarValue()
    // {
    //     return HealthBarImage.fillAmount;
    // }

    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }
}

