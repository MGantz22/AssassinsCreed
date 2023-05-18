using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthbarSlider;

    public void GiveFUllHealth(float health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
    }

    public void SetHealth(float health)
    {
        healthbarSlider.value = health;
    }
}
