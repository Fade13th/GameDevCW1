using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity {
    public float stamina;
    public float maxStamina;
    public float food;
    public float maxFood;
    public float water;
    public float maxWater;

    private UI ui;

    void Start() {
        health = maxHealth;
        stamina = maxStamina;
        food = 40;
        water = maxWater;

        ui = new UI();
        ui.initialize(maxHealth, maxStamina, maxFood, maxWater);

        ui.setHealth(health);
        ui.setStamina(stamina);
        ui.setFood(food);
        ui.setWater(water);
    }

    override
    public void addHealth(float val) {
        addHealth(val);

        ui.setHealth(health);
    }

    override
    public void removeHealth(float val) {
        removeHealth(val);

        ui.setHealth(health);
    }

    public void addStamina(float val) {
        if (stamina + val <= maxStamina)
            stamina += val;
        else
            stamina = maxStamina;

        ui.setStamina(stamina);
    }

    public void removeStamina(float val) {
        if (stamina - val <= 0)
            stamina = 0;
        else
            stamina -= val;

        ui.setStamina(stamina);
    }

    public void addFood(float val) {
        if (food + val <= maxFood)
            food += val;
        else
            food = maxFood;

        ui.setFood(food);
    }

    public void removeFood(float val) {
        if (food - val <= 0)
            food = 0;
        else
            food -= val;

        ui.setFood(food);
    }

    public void addWater(float val) {
        if (water + val <= maxWater)
            water += val;
        else
            water = maxWater;

        ui.setWater(water);
    }

    public void removeWater(float val) {
        if (water - val <= 0)
            water = 0;
        else
            water -= val;

        ui.setWater(water);
    }
}
