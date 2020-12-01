using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBity : Task {

    private PlayerController player;

    public GameObject pressButton;
    public GameObject puzzleScreen;
    public DialogueTrigger dialogueTrigger;
    private Animator anim;

    private bool isNear = false;
    private bool notOpened = true;
    private bool calledThisFrame = false;

    private static bool isBitFixed = false;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        anim = puzzleScreen.GetComponent<Animator>();

        if (isBitFixed) {
            Destroy(gameObject);
        }
    }

    void Update() {
        if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivatePuzzleScreen(false));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressButton.SetActive(true);
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressButton.SetActive(false);
            isNear = false;
        }
    }

    public void OpenPuzzle()
    {
        if (!puzzleScreen.GetComponent<BityPuzzle>().IsFinished)
        {
            dialogueTrigger.enabled = false;
            StartCoroutine(ActivatePuzzleScreen());
        }
    }

    void HandleActivation() {
        if (isNear && Input.GetKeyDown(KeyCode.E) && notOpened && !calledThisFrame)
            StartCoroutine(ActivatePuzzleScreen());
        
        else if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivatePuzzleScreen(false));
    }

    public IEnumerator ActivatePuzzleScreen() {
        calledThisFrame = true;

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.canMove = false;

        pressButton.SetActive(false);
        puzzleScreen.SetActive(true);

        yield return new WaitForSeconds(1f);
        calledThisFrame = false;
        notOpened = false;
    }

    public IEnumerator DeactivatePuzzleScreen(bool isFinished) {
        calledThisFrame = true;
        player.canMove = true;

        anim.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        if (!isFinished)
            pressButton.SetActive(true);
        else
            pressButton.SetActive(false);

        calledThisFrame = false;
        notOpened = true;

        if (isFinished)
        {
            dialogueTrigger.enabled = false;
            onTaskFinished?.Invoke();

            isBitFixed = true;
            Destroy(gameObject, 2f);
        }
            

        yield return new WaitForSeconds(0.5f);

        puzzleScreen.SetActive(false);
        //dialogueTrigger.enabled = true;
    }

    public override void DoTask(GameObject character, Action onTaskFinished)
    {
        
    }
}
