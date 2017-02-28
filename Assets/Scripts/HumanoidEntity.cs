using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidEntity : Entity {
    private Item equippedItem;

	public void Equip(Item item) {
        equippedItem = item;
    }
}
