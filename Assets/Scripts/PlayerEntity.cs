using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : HumanoidEntity {
    internal float fatigue;
    public float maxFatigue;
    internal float energy;
    public float maxEnergy;
    internal float food;
    public float maxFood;
    internal float water;
    public float maxWater;

    public float healthRegenStep;
    public float healthRegenCost;
    public float energyRegenStep;
    public float energyRegenCost;

    public float regenDelay = 0.3f;
    protected float regenTime = 0f;

    private UI ui;

    GameObject rightHand;

    void Start() {
        health = 80;
        fatigue = 0;
        energy = 10;
        food = 40;
        water = maxWater;

        ui = new UI();
        ui.initialize(maxHealth, maxFatigue, maxEnergy, maxFood, maxWater);

        ui.setHealth(health);
        ui.setFatigue(fatigue);
        ui.setEnergy(energy);
        ui.setFood(food);
        ui.setWater(water);
    }

    void Update() {
        print("Update");
        if (Time.time > regenTime) {
            if (health < maxHealth)
                regenHealth();

            if (energy < maxEnergy)
                regenEnergy();

            regenTime = Time.time + regenDelay;
        }
    }

    private void regenHealth() {
        if (food >= healthRegenCost && water >= healthRegenCost) {
            health = Mathf.Clamp(health + healthRegenStep, 0, maxHealth);
            food = Mathf.Clamp(food - healthRegenCost, 0, maxFood);
            water = Mathf.Clamp(water - healthRegenCost, 0, maxWater);

            ui.setHealth(health);
            ui.setFood(food);
            ui.setWater(water);
        }
    }

    private void regenEnergy() {
        if (fatigue < maxFatigue) {
            float healthRatio = health / maxHealth;

            fatigue = Mathf.Clamp(fatigue + energyRegenCost * healthRatio, 0, maxFatigue);
            energy = Mathf.Clamp(energy + energyRegenStep * healthRatio, 0, maxEnergy);

            ui.setFatigue(fatigue);
            ui.setEnergy(energy);
        }
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

    public void addFatigue(float val) {
        if (fatigue + val <= maxFatigue)
            fatigue += val;
        else
            fatigue = maxFatigue;

        ui.setFatigue(fatigue);
    }

    public void removeFatigue(float val) {
        if (fatigue - val <= 0)
            fatigue = 0;
        else
            fatigue -= val;

        ui.setFatigue(fatigue);
    }

    public void addEnergy(float val) {
        if (energy + val <= maxEnergy)
            energy += val;
        else
            energy = maxEnergy;

        ui.setEnergy(energy);
    }

    public void removeEnergy(float val) {
        if (energy - val <= 0)
            energy = 0;
        else
            energy -= val;

        ui.setEnergy(energy);
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

    public void useItem(Item item) {
        item.Use(this);
    }

    internal void equipItem(Item i) {
        EquipSlot slot = GameObject.Find(i.equipSlot).GetComponent<EquipSlot>();
        unequip(slot);
        GameObject obj = GameObject.Instantiate(i.equippedItem, slot.transform, false);
        slot.equippedItem = obj;
    }

    internal void unequip(EquipSlot equipSlot) {
        if (equipSlot.equippedItem != null) {
            GameObject.Destroy(equipSlot.equippedItem);
            equipSlot.equippedItem = null;
        }
    }
}
