using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health playerHealth;
    public TMP_Text coinsText;

    private void Start()
    {
        SetMaxHealth(playerHealth.maxHealth);
    }
    private void Update()
    {
        SetHealth(playerHealth.health);
        coinsText.text = slider.value.ToString();
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
