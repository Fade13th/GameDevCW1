using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float health;
    public float maxHealth;

    public float impactResist = 1;
    public float slashResist = 1;
    public float punctureResist = 1;
    public float chopResist = 1;

    public float hitDelay = 0.3f;
    private float hitTime = 0f;

    public GameObject dropItemDeath;
    public int dropRateDeath = 0;

    public GameObject dropItemHit;
    public int dropRateHit = 0;

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

    virtual
    public void dealDamage(float impact, float slash, float puncture, float chop) {
        if (Time.time > hitTime) {
            removeHealth(impact * impactResist + slash * slashResist + puncture * punctureResist + chop * chopResist);
            hitTime = Time.time + hitDelay;
            dropHit();
            print(health);
        }
    }

    private void die() {
        dropDeath();
        Destroy(this.gameObject);
    }

    private void dropHit() {
        if (dropRateHit > 0) { 
            for (int i = 0; i < dropRateHit; i++) {
                GameObject.Instantiate(dropItemHit, this.transform.position, this.transform.rotation);
            }
        }
    }

    private void dropDeath() {
        if (dropRateDeath > 0) {
            for (int i = 0; i < dropRateDeath; i++) {
                GameObject.Instantiate(dropItemDeath, this.transform.position, this.transform.rotation);
            }
        }
    }
}
