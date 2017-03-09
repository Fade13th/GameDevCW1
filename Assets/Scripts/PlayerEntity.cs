using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEntity : HumanoidEntity {
    public float fatigue;
    public float maxFatigue;
    public float energy;
    public float maxEnergy;
    public float food;
    public float maxFood;
    public float water;
    public float maxWater;

    public float healthRegenStep;
    public float healthRegenCost;
    public float energyRegenStep;
    public float energyRegenCost;

    public float regenThreshold = 20;

    public float foodDrain;
    public float waterDrain;
    public float fatigueBuildup;

    public float regenDelay = 0.3f;
    protected float regenTime = 0f;

    private float energyTime;
    public float energyDelay = 1f;

    private UI ui;

    public Inventory inv;

    GameObject rightHand;

    void Start() {
        
        ui = new UI();
        ui.initialize(maxHealth, maxFatigue, maxEnergy, maxFood, maxWater);

        ui.setHealth(health);
        ui.setFatigue(fatigue);
        ui.setEnergy(energy);
        ui.setFood(food);
        ui.setWater(water);
    }

    void Update() {
        if (Time.time > regenTime) {

            removeFood(foodDrain);
            removeWater(waterDrain);
            addFatigue(fatigueBuildup);

            if (health < maxHealth)
                regenHealth();

            if (energy < maxEnergy)
                regenEnergy();

            if (fatigue == maxFatigue)
                PassOut();

            regenTime = Time.time + regenDelay;
        }
        
    }

    private void regenHealth() {
        if (food >= regenThreshold && water >= regenThreshold) {
            addHealth(healthRegenStep);
            removeFood(healthRegenCost);
            removeWater(healthRegenCost);

            ui.setHealth(health);
            ui.setFood(food);
            ui.setWater(water);
        } 
    }

    private void regenEnergy() {
        if (Time.time > energyTime && fatigue < maxFatigue) {
            float healthRatio = health / maxHealth;

            addFatigue(energyRegenCost);
            addEnergy(energyRegenStep * healthRatio);

            ui.setFatigue(fatigue);
            ui.setEnergy(energy);
        }
    }

    override
    public void addHealth(float val) {
        if (health + val <= maxHealth)
            health += val;
        else
            health = maxHealth;

        ui.setHealth(health);
    }

    override
    public void removeHealth(float val) {
        if (health - val <= 0)
            SceneManager.LoadScene(1);
        else
            health -= val;

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

    public bool removeEnergy(float val) {
        if (energy >= val) {
            energy -= val;
            energyTime = Time.time + energyDelay;
            ui.setEnergy(energy);
            return true;
        }
        return false;
    }

    public void addFood(float val) {
        if (food + val <= maxFood)
            food += val;
        else
            food = maxFood;

        ui.setFood(food);
    }

    public void removeFood(float val) {
        if (food - val <= 0) {
            removeHealth(val - food);
            food = 0;
        }
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
        if (water - val <= 0) {
            removeHealth(val - water);
            water = 0;
        }
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

    internal void PassOut() {
        Fader fade = GameObject.Find("FadePanel").GetComponent<Fader>();
        fade.Fade();

        removeFatigue(40);
        removeFood(25);
        removeWater(25);
    }
}
