using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithLock : MonoBehaviour {

    private PlayerController player;

    public float timeBtwOpen = 1f;

    public GameObject pressButton;
    public GameObject codeLockUI;
    private Animator codeLockAnim;
    private CircleCollider2D useArea;
    
    private bool isNear = false;
    private bool notOpened = true;
    private bool calledThisFrame = false;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        codeLockAnim = codeLockUI.GetComponent<Animator>();
        useArea = GetComponent<CircleCollider2D>();
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
            StartCoroutine(ActivateLockScreen());
        
        else if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivateLockScreen(false));
    }

    public IEnumerator ActivateLockScreen() {
        calledThisFrame = true;

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.canMove = false;

        pressButton.SetActive(false);
        codeLockUI.SetActive(true);

        yield return new WaitForSeconds(timeBtwOpen);
        calledThisFrame = false;
        notOpened = false;
    }

    public IEnumerator DeactivateLockScreen(bool isFinished) {
        calledThisFrame = true;
        player.canMove = true;

        codeLockAnim.SetTrigger("Close");

        if (!isFinished)
            pressButton.SetActive(true);
        else
            pressButton.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        calledThisFrame = false;
        notOpened = true;

        if (isFinished)
            useArea.enabled = false;

        yield return new WaitForSeconds(0.5f);

        codeLockUI.SetActive(false);
    }

}
