using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterItem : Item {
    override
    public void Use(PlayerEntity player) {
        Fader fade = GameObject.Find("FadePanel").GetComponent<Fader>();
        fade.Fade();

        player.removeFatigue(100);
        player.addEnergy(100);
        player.addHealth(30);
        player.removeFood(25);
        player.removeWater(25);
    }
}
