using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour {

    public GameObject projectile;
    public Transform shotSpawn;
    public Transform aimingReference;
    public float speed;
    private float firetime;
    public float firespeed;

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > firetime)
        {
            firetime = Time.time + firespeed;
            GameObject rock = Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            rock.GetComponent<Rigidbody>().velocity = aimingReference.forward * speed;
        }
    }
}
