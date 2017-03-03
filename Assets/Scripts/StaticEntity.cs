using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEntity : Entity {
    override
    public void dealDamage(float impact, float slash, float puncture, float chop) {
        if (Time.time > hitTime) {
            float damage = impact * impactResist + slash * slashResist + puncture * punctureResist + chop * chopResist;
            removeHealth(damage);
            hitTime = Time.time + hitDelay;
            dropHit();

            this.transform.Translate(Vector3.down * (damage / maxHealth) * (60 * this.GetComponent<Renderer>().bounds.size.y / 100));
        }
    }
}
