using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public float weight;
    public string description;
    public bool usable;

    protected Inventory inv;

    void Start() {
        inv = GameObject.Find("Player").GetComponent<Inventory>();
    }

    virtual
    public void Use() { }
}
