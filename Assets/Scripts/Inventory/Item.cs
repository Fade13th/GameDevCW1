using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public float weight;
    public string description;
    public bool usable = false;
    public bool equipable = true;

    public GameObject equippedItem;
    public string equipSlot;

    protected Inventory inv;

    void Start() {
        inv = GameObject.Find("Player").GetComponent<Inventory>();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
            inv.addItem(this);
    }

    virtual
    public void Use(PlayerEntity player) { }
}
