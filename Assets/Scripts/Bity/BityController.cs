using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BityController : MonoBehaviour {

    private Animator playerAnim = default;

    [SerializeField] GameObject bity = default;
    private Animator bityAnim = default;

    [SerializeField] Transform bityFollowPoint = default;

    [SerializeField] GameObject circleLight = default;
    [SerializeField] GameObject shortFlashlight = default;
    [SerializeField] GameObject longFlashlight = default;

    private bool shortFlashlightOn = false;
    private bool longFlashlightOn = false;

    public bool canFollow = true;
    
    public bool isLR = false;
    public bool isUP = false;
    public bool isDOWN = false;

    private float followSpeed = 1.8f;

    void Start() {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        bityAnim = bity.GetComponent<Animator>();
    }

    void Update() {
        HandleInputs();
    }

    void FixedUpdate() {
        HandleMovement();
    }

    void LateUpdate() {
        UpdateBityAnimation();
    }

    void HandleMovement() {
        if (canFollow)
            transform.position = Vector2.Lerp(transform.position, bityFollowPoint.position, followSpeed * Time.deltaTime);
    }

    void HandleInputs() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (!shortFlashlightOn && !longFlashlightOn) 
            {
                circleLight.SetActive(true);

                FMODUnity.RuntimeManager.PlayOneShot("event:/sfx_gameplay/bity_lanterna_foco fechado (pitch)", gameObject.transform.position);
                shortFlashlight.SetActive(true);
                
                shortFlashlightOn = true;
            }
            else if (shortFlashlightOn) {
                shortFlashlight.SetActive(false);
                shortFlashlightOn = false;

                FMODUnity.RuntimeManager.PlayOneShot("event:/sfx_gameplay/bity_lanterna_foco aberto (pitch)", gameObject.transform.position);
                longFlashlight.SetActive(true);
                
                longFlashlightOn = true;
            }
            else 
            {
                circleLight.SetActive(false);
                longFlashlight.SetActive(false);
                longFlashlightOn = false;
            }
        }
    }

    void UpdateBityAnimation() {
        if (canFollow) {
            if (playerAnim.GetBool("WalkingUP")) {
                bityAnim.SetBool("Up", true);
                bityAnim.SetBool("Down", false);
                bityAnim.SetBool("LR", false);
            }
            if (playerAnim.GetBool("WalkingDOWN")) {
                bityAnim.SetBool("Up", false);
                bityAnim.SetBool("Down", true);
                bityAnim.SetBool("LR", false);
            }
            if (playerAnim.GetBool("WalkingLR")) {
                bityAnim.SetBool("Up", false);
                bityAnim.SetBool("Down", false);
                bityAnim.SetBool("LR", true);

                if (GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.y == 180f) {
                    bity.transform.eulerAngles = new Vector3(bity.transform.eulerAngles.x, 180f, bity.transform.eulerAngles.z);
                } else {
                    bity.transform.eulerAngles = new Vector3(bity.transform.eulerAngles.x, 0f, bity.transform.eulerAngles.z);
                }
            }
        }
        
        if (isUP) {
            bityAnim.SetBool("Up", true);
            bityAnim.SetBool("Down", false);
            bityAnim.SetBool("LR", false);
        }
        if (isDOWN) {
            bityAnim.SetBool("Up", false);
            bityAnim.SetBool("Down", true);
            bityAnim.SetBool("LR", false);
        }
        if (isLR) {
            bityAnim.SetBool("Up", false);
            bityAnim.SetBool("Down", false);
            bityAnim.SetBool("LR", true);
        }
    }

}
