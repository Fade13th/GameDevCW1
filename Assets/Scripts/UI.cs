using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject character;

    Slider healthBar, staminaBar, foodBar, waterBar;
    Text healthText, staminaText, foodText, waterText;

    public void initialize (float maxHealth, float maxStamina, float maxFood, float maxWater) {
        healthBar = GameObject.Find("Health").GetComponent<Slider>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        staminaBar = GameObject.Find("Stamina").GetComponent<Slider>();
        staminaText = GameObject.Find("StaminaText").GetComponent<Text>();
        foodBar = GameObject.Find("Food").GetComponent<Slider>();
        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        waterBar = GameObject.Find("Water").GetComponent<Slider>();
        waterText = GameObject.Find("WaterText").GetComponent<Text>();

        healthBar.maxValue = maxHealth;
        staminaBar.maxValue = maxStamina;
        foodBar.maxValue = maxFood;
        waterBar.maxValue = maxWater;
    }
	
	public void setHealth(float health) {
        float x = Mathf.Ceil(health);
        healthBar.value = x;
        healthText.text = x.ToString();
    }

    public void setStamina(float stamina) {
        float x = Mathf.Ceil(stamina);
        staminaBar.value = x;
        staminaText.text = x.ToString();
    }

    public void setFood(float food) {
        float x = Mathf.Ceil(food);
        foodBar.value = x;
        foodText.text = x.ToString();
    }

    public void setWater(float water) {
        float x = Mathf.Ceil(water);
        waterBar.value = x;
        waterText.text = x.ToString();
    }
}
