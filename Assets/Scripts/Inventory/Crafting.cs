using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {
    Dictionary<string, Item> allItems;

    CanvasGroup group;

    ScrollRect list;
    Text components;
    Text detail;
    Button craftButton;

    Inventory inv;

    string currentItem;

    // Use this for initialization
    void Start () {
        allItems = Inventory.loadItems();

        list = GameObject.Find("craft_scroll").GetComponent<ScrollRect>();
        components = GameObject.Find("craft_components").GetComponent<Text>();
        detail = GameObject.Find("craft_detail").GetComponent<Text>();
        craftButton = GameObject.Find("craft_craft").GetComponent<Button>();

        group = GetComponent<CanvasGroup>();

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        hide();

        setup();
    }

    private void setup() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("craft_item")) {
            Destroy(obj);
        }

        detail.text = "";
        components.text = "";

        int n = 0;

        foreach (string i in allItems.Keys) {
            Item item = allItems[i];

            if (item.craftable) {
                GameObject row = (GameObject)Instantiate(Resources.Load("craft_Item"));

                Text name = row.transform.Find("Name").GetComponent<Text>();

                name.text = i;

                row.transform.parent = list.transform;
                row.transform.localPosition = new Vector3(-9, (135 - n * 26), 0);

                row.transform.SetAsLastSibling();

                n++;
            }
        }

        craftButton.GetComponent<Image>().color = Color.gray;
    }

    public void Craft() {
        Item item = allItems[currentItem];

        string[] comps = item.craftComps.Replace(" ","").Split(',');

        foreach (string s in comps) {
            string[] split = s.Split(':');
            inv.removeItem(split[0], int.Parse(split[1]));
        }

        inv.addItem(currentItem);

        setup();
    }

    public void setDescription(string item) {
        currentItem = item;

        bool hasComponents = true;
        string comps = "";

        string[] compsSplit = allItems[item].craftComps.Replace(" ", "").Split(',');

        foreach (string s in compsSplit) {
            string[] split = s.Split(':');
            if (!inv.hasItem(split[0], int.Parse(split[1])))
                hasComponents = false;

            int owned = 0;
            if (inv.contents.ContainsKey(split[0]))
                owned = inv.contents[split[0]];

            comps += split[0] + " x" + split[1] + " Owned: " + owned + "\n";
        }

        components.text = comps;
        detail.text = allItems[item].description;
        craftButton.enabled = hasComponents;
        craftButton.GetComponent<Image>().color = hasComponents ? Color.white : Color.gray;
    }

    public void show() {
        setup();
        group.alpha = 1;
        group.blocksRaycasts = true;
    }

    public void hide() {
        group.alpha = 0;
        group.blocksRaycasts = false;
    }
}
