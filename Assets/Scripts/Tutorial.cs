using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    private Text text;
    private Button next;
    private int stage = 0;

    private Image health_highlight, fatigue_highlight, energy_highlight, food_highlight, water_highlight;

    private bool waiting = false;

    private WaitFunction waitFunc;

    private Inventory inv;

    private string targetItem;

    private GameObject quitConfirm;

    // Use this for initialization
    void Start () {
        text = GameObject.Find("tut_text").GetComponent<Text>();
        next = GameObject.Find("tut_next").GetComponent<Button>();

        health_highlight = GameObject.Find("highlight_health").GetComponent<Image>();
        fatigue_highlight = GameObject.Find("highlight_fatigue").GetComponent<Image>();
        energy_highlight = GameObject.Find("highlight_energy").GetComponent<Image>();
        food_highlight = GameObject.Find("highlight_food").GetComponent<Image>();
        water_highlight = GameObject.Find("highlight_water").GetComponent<Image>();

        health_highlight.enabled = false;
        fatigue_highlight.enabled = false;
        energy_highlight.enabled = false;
        food_highlight.enabled = false;
        water_highlight.enabled = false;

        quitConfirm = GameObject.Find("tut_quit_confirm");

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        UpdateTutorial();
    }

    private delegate bool WaitFunction();

    void Update() {
        if (waiting && waitFunc()) {
            waitFunc = null;
            targetItem = null;
            waiting = false;
            nextStep();
            UpdateTutorial();
        }
    }

    private bool WaitForItem() {
        return inv.hasItem(targetItem, 1);
    }

    private bool WaitForNot() {
        return !inv.hasItem(targetItem, 1);
    }

    private bool EquipItem() {
        return inv.equippedItem.Equals(targetItem);
    }
	
	private void UpdateTutorial () {
		switch(stage) {
            case 0 :
                text.text = "Welcome. This tutorial will introduce you to the basics of survival. You can close the tutorial at any time by pressing 'Quit'. Press 'Esc' to unlock the mouse from the camera and click the arrow button to continue.";
                enableNext(true);
                break;

            case 1 :
                text.text = "This is your health. If this bar reaches 0, you will die.";
                health_highlight.enabled = true;
                break;

            case 2:
                text.text = "This is your fatigue. Fatigue will build up over time, and will increase quicker when recharging your energy. If this fills up, you will pass out. You can reduce fatigue by resting.";
                health_highlight.enabled = false;
                fatigue_highlight.enabled = true;
                break;

            case 3:
                text.text = "This is your energy. Energy is used to perform actions such as swinging tools or sprinting. Energy will recharge over time at the cost of building fatigue. You will recharge energy quicker if you have more health.";
                fatigue_highlight.enabled = false;
                energy_highlight.enabled = true;
                break;

            case 4:
                text.text = "This is your food bar. You will take damage over time if this becomes empty. Food and water will be drained to gradually regenerate health. Find and consume food in the world to fill this bar.";
                energy_highlight.enabled = false;
                food_highlight.enabled = true;
                break;

            case 5:
                text.text = "This is your water bar. Like food, you will take damage if this is empty and regenerate health in exchange for both this and food. Find a water source to drink or fill a waterproof container.";
                food_highlight.enabled = false;
                water_highlight.enabled = true;
                break;

            case 6:
                text.text = "You'll need to gather water to survive. Walk out into a river or lake (you'll have to go a few steps before the water's deep enough) and you should see water appear in your inventory. \n\nObjective: Find a body of water.";
                enableNext(false);
                waiting = true;
                targetItem = "Water";
                waitFunc = WaitForItem;
                break;

            case 7:
                text.text = "Open your inventory with the 'I' key, select the water and click use to refill some of your water bar";
                enableNext(true);
                break;

            case 8:
                text.text = "You'll want to take some water with you. You may have noticed an empty canteen in your inventory, you can fill it with water using the crafting menu. Open the crafting menu with 'U' and craft a canteen full of water. \n\nObjective: craft a filled canteen.";
                enableNext(false);
                waiting = true;
                targetItem = "Canteen (Water)";
                waitFunc = WaitForItem;
                break;

            case 9:
                text.text = "Now you have water, you'll need to build tools to survive in the wilderness. The first step is to gather rocks to use as a makeshift tool and for use in crafting. \n\nObjective: Find a rock.";
                water_highlight.enabled = false;
                waiting = true;
                targetItem = "Dwayne";
                waitFunc = WaitForItem;
                break;

            case 10:
                text.text = "Now open your inventory and select your rock. Click 'Equip' to weild it as a makeshift tool. \n\nObjective: Equip a rock.";
                waiting = true;
                targetItem = "Dwayne";
                waitFunc = EquipItem;
                break;

            case 11:
                text.text = "Try hitting a tree with your new tool. Using items like rocks are much less efficient that real tools, but try to break off and gather some sticks. \n\nObjective: Collect a stick by attacking a tree.";
                waiting = true;
                targetItem = "Stick";
                waitFunc = WaitForItem;
                break;

            case 12:
                text.text = "Now you can start crafting! Open the crafting menu with 'U' and combine your rock and stick into an axe. Equip your new axe to make harvesting food much more efficient. \n\nObjective: Craft and equip an axe.";
                waiting = true;
                targetItem = "Axe";
                waitFunc = EquipItem;
                break;
           
            case 13:
                text.text = "Now you'll need to gather food. Try cutting down a tree with your new axe to get some apples. \n\nObjective: Cut down trees to find some apples.";
                waiting = true;
                targetItem = "Apple";
                waitFunc = WaitForItem;
                break;

            case 14:
                text.text = "Fruit is useful as a food source, but is much less efficient than meat. Find some wild animals and attack them with your axe to get some. \n\nObjective: Hunt for meat.";
                waiting = true;
                targetItem = "Raw Meat";
                waitFunc = WaitForItem;
                break;

            case 15:
                text.text = "Some animals also drop useful biproducts like leather. Make sure to collect it: you don't know when it'll come in handy. \n\nObjective: Collect leather from your recent kill";
                waiting = true;
                targetItem = "Leather";
                waitFunc = WaitForItem;
                break;

            case 16:
                text.text = "Raw meat doesn't fill up as much food as cooked meat. You'll need a source of fire. Check the crafting menu and collect the resources needed to craft a campfire and craft it. \n\nObjective: Craft a campfire";
                waiting = true;
                targetItem = "Campfire";
                waitFunc = WaitForItem;
                break;

            case 17:
                text.text = "Place your new campfire by clicking 'Use' on it in your inventory.\n\nObjective: Place the campfire";
                waiting = true;
                targetItem = "Campfire";
                waitFunc = WaitForNot;
                break;

            case 18:
                text.text = "Stand near your campfire to gain access to 'Fire' as a crafting material. Combine this with some raw meat to cook it. \n\nObjective: Cook some raw meat.";
                waiting = true;
                targetItem = "Cooked Meat";
                waitFunc = WaitForItem;
                break;

            case 19:
                text.text = "When your fatigue builds up you'll need to rest to recover. To do so, you'll need a tent. Find the components and craft a tent. \n\nObjective: Craft a tent.";
                waiting = true;
                targetItem = "Tent";
                waitFunc = WaitForItem;
                break;

            case 20:
                text.text = "To sleep in your tent, get close and select 'Use' on the 'Nearby Tent' item in your inventory. This will restore your fatigue, energy and health at the cost of some food and water. \n\nObjective: Sleep in your tent.";
                enableNext(true);
                break;

            case 21:
                text.text = "You now know the basics you need to survive in this world. Continue exploring to discover new lands, wild and possibly hostile creatures, and eventually find your way back to civilisation.";
                enableNext(false);
                break;

            default:
                health_highlight.enabled = false;
                fatigue_highlight.enabled = false;
                energy_highlight.enabled = false;
                food_highlight.enabled = false;
                water_highlight.enabled = false;
                break;
        }
	}

    private void enableNext(bool enable) {
        next.enabled = enable;
        next.GetComponent<Image>().enabled = enable;
        next.GetComponentInChildren<Text>().enabled = enable;
    }

    public void nextStep() {
        stage++;
        UpdateTutorial();
    }

    public void OpenQuitConfirm() {
        CanvasGroup group = quitConfirm.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void CloseQuitConfirm() {
        CanvasGroup group = quitConfirm.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }

    public void Quit() {
        Destroy(GameObject.Find("TutorialCanvas"));
    }
}
