using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public float weight;
    public string description;
    public bool usable = false;
    public bool equipable = true;
    public bool craftable = false;
    public string craftComps;

    public GameObject equippedItem;
    public string equipSlot;

    protected Inventory inv;
    protected Crafting craft;

    void Start() {
        inv = GameObject.Find("Player").GetComponent<Inventory>();
        craft = GameObject.Find("Crafting").GetComponent<Crafting>();
        craftComps = craftComps.Replace(" ", "");
    }

    virtual
    public void Use(PlayerEntity player) { }
}
