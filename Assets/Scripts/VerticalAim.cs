using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAim : MonoBehaviour {
    public float rotateSpeed = 5.0F;
    public float rotMin = 0;
    public float rotMax = 360;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        Transform transform = GetComponent<Transform>();

        float angle = transform.localRotation.eulerAngles.x;
        float newAngle= angle - vertical;

        if (newAngle > 180)
            newAngle = Mathf.Max(newAngle, 360 + rotMin);
        else
            newAngle = Mathf.Min(newAngle, rotMax);
    
        transform.localRotation = Quaternion.Euler(newAngle, 0, 0);
    }
}
