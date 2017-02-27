using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : Item {

    void Start() {
        itemName = "Pear";
        weight = 0.5f;
        description = "A ripe pear. Eat to restore 10 food";
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
