using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    public float impact;
    public float slash;
    public float puncture;
    public float chop;

	private bool isLive = false;

    public void OnCollisionEnter(Collision collision) {
        Entity entity = collision.gameObject.GetComponent<Entity>();

		if (isLive && entity != null) {
			entity.dealDamage (impact, slash, puncture, chop);
		}
    }

	public void enable(bool bEnabled) {
		this.isLive = bEnabled;
	}
}
