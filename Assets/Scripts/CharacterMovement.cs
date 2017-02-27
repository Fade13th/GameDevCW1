using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float walkSpeed = 6.0F;
    public float runSpeed = 12.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private MouseAim aim;
    private VerticalAim vaim;
    private ThrowRock fire;

    private Inventory inv;

    void Start() {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        aim = GetComponent<MouseAim>();
        vaim = GameObject.Find("CameraContainer").GetComponent<VerticalAim>();
        fire = GetComponent<ThrowRock>();
    }

    private Vector3 moveDirection = Vector3.zero;
    void Update() {
        float speed;

        if (Input.GetButton("Sprint"))
            speed = runSpeed;
        else
            speed = walkSpeed;

        if (Input.GetButtonDown("Inventory")) {
            if (!aim.enabled) {
                inv.hide();
                aim.enabled = true;
                vaim.enabled = true;
                fire.enabled = true;
            }
            else {
                inv.show();
                aim.enabled = false;
                vaim.enabled = false;
                fire.enabled = false;
            }
        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        //Pick up item
        Item item = hit.gameObject.GetComponent<Item>();
        if (item != null) {
            inv.addItem(item);
            Destroy(item.gameObject);
        }
    }
}
