using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftRow : MonoBehaviour {
    private Crafting craft;

	// Use this for initialization
	void Start () {
	    craft = GameObject.Find("Crafting").GetComponent<Crafting>();	
	}

    public void select() {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("craft_item"))
            i.GetComponent<Image>().color = Color.gray;

        GetComponent<Image>().color = Color.white;
        craft.setDescription(transform.Find("Name").GetComponent<Text>().text);
    }
}
