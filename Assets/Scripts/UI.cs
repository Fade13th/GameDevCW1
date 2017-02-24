using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public GameObject character;
    private Entity entity;

    GameObject healthBar, healthText;
    GameObject staminaBar, StaminaText;
    GameObject FoodBar, FoodText;
    GameObject WaterBar, WaterText;

    // Use this for initialization
    void Start () {
        entity = character.GetComponent<Entity>();
        healthBar = GameObject.Find("Health");
        healthText = GameObject.Find("HealthText");
        staminaBar = GameObject.Find("Stamina");
    }
	
	public void setHealth(float health) {

    }
}
