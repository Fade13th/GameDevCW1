using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRow : MonoBehaviour {
    public Item item;
    private Inventory inv;

    void Start() {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void select() {
        inv.setDescription(transform.Find("Name").GetComponent<Text>().text);
    }
}
