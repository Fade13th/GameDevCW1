using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableItem : Item {

    public Entity placedEntity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override
    public void Use (PlayerEntity player) {
        Transform point = player.transform.Find("PlacePoint");
        Entity obj = GameObject.Instantiate(placedEntity);
        obj.transform.position = point.position;
        base.Use(player);
    }
}
