using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieUI : MonoBehaviour
{
    public Zombie zombie;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = zombie.health;
        healthSlider.value = zombie.health;

        zombie.HealthChanged += UpdateHealthBar;
    }

    public void UpdateHealthBar()
    {
        healthSlider.value = zombie.health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthSlider.value = zombie.health;
        transform.rotation = Quaternion.identity;
    }
}
