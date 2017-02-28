using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    public float impact;
    public float slash;
    public float puncture;
    public float chop;

    public void OnCollisionEnter(Collision collision) {
        Entity entity = collision.gameObject.GetComponent<Entity>();

        if (entity != null)
            entity.dealDamage(impact, slash, puncture, chop);

        print("Hit");
    }
}
