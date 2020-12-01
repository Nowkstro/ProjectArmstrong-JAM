using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneBeforeDialogTrigger : MonoBehaviour {
    
    public GameObject pressButton;
    private BoxCollider2D boxCollider2D;
    
    public UnityEvent OnPressButton;

    private bool isNear = false;
    private bool alreadyPlayed = false;

    void Start() {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update() {
        HandleActivation();
    }

    void HandleActivation() {
        if (isNear && Input.GetKeyDown(KeyCode.E) && !alreadyPlayed) {
            alreadyPlayed = true;
            pressButton.SetActive(false);
            OnPressButton?.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !alreadyPlayed) {
           pressButton.SetActive(true);
           isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !alreadyPlayed) {
           pressButton.SetActive(false);
           isNear = false;
        }
    }

}
