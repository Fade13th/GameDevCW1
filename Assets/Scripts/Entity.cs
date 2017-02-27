using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float health;
    public float maxHealth;

    virtual
	public void addHealth(float val) {
        if (health + val <= maxHealth)
            health += val;
        else
            health = maxHealth;
    }

    virtual
    public void removeHealth(float val) {
        if (health - val <= 0)
            die();
        else
            health -= val;   
    }

    private void die() {

    }
}
