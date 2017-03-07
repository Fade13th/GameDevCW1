using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float walkSpeed = 6.0F;
    public float runSpeed = 12.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private float speed;

    private MouseAim aim;
    private VerticalAim vaim;
    private ThrowRock fire;

    private Inventory inv;

    private PlayerEntity player;

    public float swingCost;
    protected float swingTime = 0f;

    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerEntity>();

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        aim = GetComponent<MouseAim>();
        vaim = GameObject.Find("CameraContainer").GetComponent<VerticalAim>();
        fire = GetComponent<ThrowRock>();
        speed = walkSpeed;
    }

    private Vector3 moveDirection = Vector3.zero;
    void Update() {

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

    public void toggleSprint(bool sprint) {
        speed = sprint ? runSpeed : walkSpeed;
    }

    public void enableMouse(bool enable) {
        aim.enabled = enable;
        vaim.enabled = enable;
        //fire.enabled = enable;
    }

    internal bool canSwing() {
        return player.energy >= swingCost;
    }

    internal void swing() {
        if (Time.time > swingTime) {
            player.removeEnergy(swingCost);
            swingTime = Time.time + 2.4f;
        }
    }
}
