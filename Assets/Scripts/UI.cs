using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject character;

    Slider healthBar, staminaBar, foodBar, waterBar;
    Text healthText, staminaText, foodText, waterText;

    Button inv_btn;
    Button crf_btn;

    CanvasGroup buttons;

    private Inventory inventory;
    private Crafting crafting;

    private bool inventoryOpen = false;
    private bool craftingOpen = false;

    public void Start() {
        inv_btn = GameObject.Find("Inventory_btn").GetComponent<Button>();
        crf_btn = GameObject.Find("Crafting_btn").GetComponent<Button>();

        buttons = GameObject.Find("Buttons").GetComponent<CanvasGroup>();
        buttons.alpha = 0;

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        crafting = GameObject.Find("Crafting").GetComponent<Crafting>();
    }

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

    public bool isOpen() {
        return inventoryOpen || craftingOpen;
    }

    public void toggleInventory() {
        if (craftingOpen) {
            crafting.hide();
            craftingOpen = false;
            crf_btn.enabled = true;
        }

        if (inventoryOpen) {
            inventory.hide();
            inventoryOpen = false;
            disableCrfBtn();
            buttons.alpha = 0;
        }
        else {
            inventory.show();
            inventoryOpen = true;
            disableInvBtn();
            buttons.alpha = 1;
        }
    }

    public void toggleCrafting() {
        if (inventoryOpen) {
            inventory.hide();
            inventoryOpen = false;
        }

        if (craftingOpen) {
            crafting.hide();
            craftingOpen = false;
            disableInvBtn();
            buttons.alpha = 0;
        }
        else {
            crafting.show();
            craftingOpen = true;
            disableCrfBtn();
            buttons.alpha = 1;
        }
    }

    private void disableCrfBtn() {
        inv_btn.enabled = true;
        crf_btn.enabled = false;

        inv_btn.GetComponent<Image>().color = Color.white;
        crf_btn.GetComponent<Image>().color = Color.gray;
    }

    private void disableInvBtn() {
        inv_btn.enabled = false;
        crf_btn.enabled = true;

        inv_btn.GetComponent<Image>().color = Color.gray;
        crf_btn.GetComponent<Image>().color = Color.white;
    }
}
