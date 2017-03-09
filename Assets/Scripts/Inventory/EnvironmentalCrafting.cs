using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalCrafting : MonoBehaviour {

    public Item inventoryItem;

    public void OnTriggerStay(Collider other) {
        PlayerEntity player = other.GetComponent<PlayerEntity>();
        if (player != null) {
            Inventory inv = player.inv;
            if (!inv.hasItem(inventoryItem.itemName, 1)) {
                inv.addItem(inventoryItem.itemName);
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        PlayerEntity player = other.GetComponent<PlayerEntity>();
        if (player != null) {
            Inventory inv = player.inv;
            while (inv.hasItem(inventoryItem.itemName, 1)) {
                inv.removeItem(inventoryItem.itemName);
            }
        }
    }
}
