using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider dashBar;
    public Slider flowerBar;
    public Slider healthBar;

    public float flower;

    public void UpdateDash(float dash)
    {
        dashBar.value = dash;
    }
    public void UpdateHealth(float health)
    {
        //SetHealth(health);
        healthBar.value = health;
    }
    public void UpdateFlower()
    {
        flower++;
        flowerBar.value = flower;
    }
}
