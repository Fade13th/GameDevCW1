using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    public float impact;
    public float slash;
    public float puncture;
    public float chop;

	private bool isLive = false;

    public void OnTriggerEnter(Collider collision) {
        if (isLive) {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            if (entity != null && entity != GameObject.Find("Player").GetComponent<Entity>()) {
                entity.dealDamage(impact, slash, puncture, chop);
            }
        }
    }

	public void enable(bool bEnabled) {
		this.isLive = bEnabled;
	}
}
