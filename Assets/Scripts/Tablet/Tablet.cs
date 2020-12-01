using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {
    
    private PlayerController player;

    public float timeBtwOpen = 1f;

    public GameObject pressButton;
    public GameObject tablet;
    private GameObject lightSrc;
    private Animator tabletAnim;
    
    private bool isNear = false;
    private bool notOpened = true;
    private bool calledThisFrame = false;
    private static bool openedFirstTime = false;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        tabletAnim = tablet.GetComponent<Animator>();
        lightSrc = transform.GetChild(0).gameObject;

        if (openedFirstTime)
            Destroy(lightSrc);
    }

    void Update() {
        HandleActivation();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
           pressButton.SetActive(true);
           isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
           pressButton.SetActive(false);
           isNear = false;
        }
    }

    void HandleActivation() {
        if (isNear && Input.GetKeyDown(KeyCode.E) && notOpened && !calledThisFrame)
            StartCoroutine(ActivateTabletScreen());
        
        else if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivateTabletScreen());
    }

    public IEnumerator ActivateTabletScreen() {
        openedFirstTime = true;

        calledThisFrame = true;

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.canMove = false;

        pressButton.SetActive(false);
        tablet.SetActive(true);

        yield return new WaitForSeconds(timeBtwOpen);
        calledThisFrame = false;
        notOpened = false;
    }

    public IEnumerator DeactivateTabletScreen() {
        calledThisFrame = true;
        player.canMove = true;

        tabletAnim.SetTrigger("Close");

        pressButton.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        calledThisFrame = false;
        notOpened = true;

        if (openedFirstTime)
            Destroy(lightSrc);

        yield return new WaitForSeconds(0.5f);

        tablet.SetActive(false);
    }
}
