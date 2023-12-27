using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image bloodOverlayImage;
    public Slider slider;
    void Start()
    {
        var tempColour = bloodOverlayImage.color;
        tempColour.a = 0f;
        bloodOverlayImage.color = tempColour;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        var tempColour = bloodOverlayImage.color;
        tempColour.a = Mathf.Clamp((1-((health/250) + 0.5f)) * 2, 0, 1);
        bloodOverlayImage.color = tempColour;
        //Debug.Log("Alpha: " + bloodOverlayImage.color.a + "Number: " + Mathf.Clamp(health - 0.5f, 1, 0));
    }
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }
}
