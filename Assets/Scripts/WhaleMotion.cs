using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMotion : MonoBehaviour {

    public float speed;
    public float gravity = 20.0F;

    private float timeToChange = 0;

    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 moveDirection;

        if (timeToChange < Time.time) {
            transform.RotateAround(transform.position, transform.up, Random.Range(-1f,1f)*45+180);
            timeToChange = Time.time + 25 + Random.Range(0,11);
        }

        moveDirection = transform.forward * -speed * Time.deltaTime;
        moveDirection.y = -gravity * Time.deltaTime;
        controller.Move(moveDirection);

    }
}
