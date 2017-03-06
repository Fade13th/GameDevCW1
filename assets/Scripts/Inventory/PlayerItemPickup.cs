using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickup : MonoBehaviour {

	public Inventory inv;

	void OnTriggerEnter(Collider hit) {
		print ("Trigger collision");
		//Pick up item
		Item item = hit.gameObject.GetComponent<Item>();
		if (item != null) {
			print(item.itemName);
			inv.addItem(item.itemName);
			Destroy(item.gameObject);
		}
	}

}
