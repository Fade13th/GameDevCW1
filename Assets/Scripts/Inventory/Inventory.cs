using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    Dictionary<string, int> contents;
    Dictionary<string, Item> allItems;

    ScrollRect list;
    Image image;
    Text detail;
    Button useButton;
    Button equipButton;

    public PlayerEntity player; 

    CanvasGroup group;

    string currentItem;

	// Use this for initialization
	void Start () {
        contents = new Dictionary<string, int>();
        allItems = loadItems();

        list = GameObject.Find("inv_Scroll").GetComponent<ScrollRect>();
        image = GameObject.Find("inv_Image").GetComponent<Image>();
        detail = GameObject.Find("inv_Detail").GetComponent<Text>();
        useButton = GameObject.Find("inv_use").GetComponent<Button>();
        equipButton = GameObject.Find("inv_equip").GetComponent<Button>();

        group = GetComponent<CanvasGroup>();

        hide();
	}

    private Dictionary<string, Item> loadItems() {
        Dictionary<string, Item> map = new Dictionary<string, Item>();

        Object[] fileEntries = Resources.LoadAll("Prefabs/Items", typeof(GameObject));

        foreach (Object o in fileEntries) {
            Item i = ((GameObject)o).GetComponent<Item>();
            print(i.itemName);
            print(i.description);
            map.Add(i.name, i);
        }

        return map;
    }

    public void show() {
        group.alpha = 1;
        group.blocksRaycasts = true;
    }

    public void hide() {
        group.alpha = 0;
        group.blocksRaycasts = false;
    }
	
	public void addItem(Item i) {
        string item = i.gameObject.GetComponent<Item>().itemName;
        if (contents.ContainsKey(item))
            contents[item] = contents[item] + 1;
        else
            contents.Add(item, 1);

        updateInv();
    }

    public void removeItem(Item i) {
        string item = i.gameObject.GetComponent<Item>().itemName;
        if (contents[item] > 1)
            contents[item] = contents[item] - 1;
        else
            contents.Remove(item);

        updateInv();
    }

    private void updateInv() {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("inv_item")) {
            Destroy(obj);
        }

        int n = 0;

        foreach (string i in contents.Keys) {
            GameObject item = (GameObject)Instantiate(Resources.Load("inv_Item"));
            Text name = item.transform.Find("Name").GetComponent<Text>();
            Text off = item.transform.Find("Off").GetComponent<Text>();

            name.text = i;
            off.text = contents[i].ToString();

            item.transform.parent = list.transform;
            item.transform.localPosition = new Vector3(-9, (135 - n*26), 0);

            item.transform.SetAsLastSibling();

            n++;
        }
    }

    public void setDescription(string item) {
        currentItem = item;
        detail.text = allItems[item].description;

        useButton.enabled = allItems[item].usable;
        equipButton.enabled = allItems[item].equipable;
    }

    public void useItem() {
        Item i = allItems[currentItem];
        player.useItem(i);

        removeItem(i);
        detail.text = "";
        useButton.enabled = false;
    }

    public void equipItem() {
        Item i = allItems[currentItem];
        player.equipItem(i);
    }
}
