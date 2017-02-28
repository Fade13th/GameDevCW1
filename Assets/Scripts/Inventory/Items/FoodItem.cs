using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item {
    public float foodVal;

    override
    public void Use(PlayerEntity player) {
        player.addFood(foodVal);
    }
}
