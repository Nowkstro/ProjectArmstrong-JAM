using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static string playerOrientation;

    [HideInInspector] public Rigidbody2D rig;

    private Animator anim;
    private BoxCollider2D col;

    public bool canMove = true;

    private bool usingGun = false;

    public bool isIdleUp = false;
    public bool isIdleDown = false;
    public bool isIdleLR = false;

    private const string WALKING_UP = "WalkingUP", 
    WALKING_DOWN = "WalkingDOWN", 
    WALKING_LR = "WalkingLR";

    public Vector2 movement;
    public float speed = 4.5f;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Turning player to correct direction on enter another scenes
        // if (playerOrientation != null)
        //     anim.Play(playerOrientation);
    }

    void FixedUpdate() {
        HandleMovement();
    }

    void HandleMovement() {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            // UP & DOWN MOVEMENT
            if (movement.y > 0) 
            {
                anim.SetBool(WALKING_UP, true);
                anim.SetBool(WALKING_LR, false);

                playerOrientation = "player_idle_up";
            }

            if (movement.y < 0) 
            {
                anim.SetBool(WALKING_DOWN, true);
                anim.SetBool(WALKING_LR, false);

                playerOrientation = "player_idle_down";
            }

            if (movement.y == 0) 
            {
                if (anim.GetBool(WALKING_UP))
                    anim.SetBool(WALKING_UP, false);
                    
                if (anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_DOWN, false);
            }

            // LEFT & RIGHT MOVEMENT
            if (movement.x > 0 || movement.x < 0) 
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_LR, true);

                    playerOrientation = "player_idle_LR";
            }

            if (movement.x == 0)
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_LR, false);
            }
        }

        if (!usingGun) {
            if (movement.x < 0 && canMove)
                transform.eulerAngles = new Vector3(0, -180f, 0);
            else if (movement.x > 0 && canMove)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (canMove)
            rig.velocity = new Vector2(movement.x, movement.y).normalized * speed;
        else {
            anim.SetBool(WALKING_DOWN, false);
            anim.SetBool(WALKING_UP, false);
            anim.SetBool(WALKING_LR, false);
        }

        if (isIdleUp)
            anim.Play("player_idle_up");

        if (isIdleDown)
            anim.Play("player_idle_down");

        if (isIdleLR) {
            anim.Play("player_idle_LR");
        }
    }

}
