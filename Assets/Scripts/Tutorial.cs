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
                text.text = "The first step to surviving in the wilderness is to gather rocks to use as a makeshift tool and for use in crafting. \n\nObjective: Find a rock.";
                water_highlight.enabled = false;
                enableNext(false);
                waiting = true;
                targetItem = "Dwayne";
                waitFunc = WaitForItem;
                break;

            case 7:
                text.text = "Now open your inventory with 'I' and select your rock. Click 'Equip' to weild it as a makeshift tool. \n\nObjective: Equip a rock.";
                waiting = true;
                targetItem = "Dwayne";
                waitFunc = EquipItem;
                break;

            case 8:
                text.text = "Try hitting a tree with your new tool. Using items like rocks are much less efficient that real tools, but try to break off and gather some sticks. \n\nObjective: Collect a stick by attacking a tree.";
                waiting = true;
                targetItem = "Stick";
                waitFunc = WaitForItem;
                break;

            case 9:
                text.text = "Now you can start crafting! Open the crafting menu with 'U' and combine your rock and stick into an axe. Equip your new axe to make harvesting food much more efficient. \n\nObjective: Craft and equip an axe.";
                waiting = true;
                targetItem = "Axe";
                waitFunc = EquipItem;
                break;

            case 10:
                text.text = "Now you'll need to gather food and water.";
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
