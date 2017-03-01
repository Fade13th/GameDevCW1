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
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("inv_item"))
            i.GetComponent<Image>().color = Color.gray;

        GetComponent<Image>().color = Color.white;
        inv.setDescription(transform.Find("Name").GetComponent<Text>().text);
    }
}
