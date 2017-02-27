using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Item {
	// Use this for initialization
	void Start () {
        itemName = "Apple";
        weight = 0.5f;
        description = "A red apple. Eat to restore 10 food.";
        usable = true;
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
            inv.addItem(this);
    }

    override
    public void Use() {
        PlayerEntity player = GameObject.Find("Player").GetComponent<PlayerEntity>();
        player.addFood(10);
    }
}
