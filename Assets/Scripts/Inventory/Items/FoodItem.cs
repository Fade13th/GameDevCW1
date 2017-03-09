using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item {
    public float foodVal;
    public float waterVal;

    override
    public void Use(PlayerEntity player) {
        base.Use(player);
        player.addFood(foodVal);
        player.addWater(waterVal);
    }
}
