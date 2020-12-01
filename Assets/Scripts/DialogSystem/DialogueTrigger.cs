using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject inputTip = default;
    [SerializeField] Task taskAfterDialogue = default;

    [SerializeField] bool playerCanMove = false;
    
    [SerializeField] List<DialogContent> conversationList = new List<DialogContent>();

    [Serializable]
    public struct DialogContent
    {
        public string currentConversation;
        public UnityEvent EventAfterDialogue;
    }

    private int currentConvesation = 0;
    private bool inTrigger = false;
    private bool dialogueLoaded = false;
    private bool inDialogue = false;
    private bool inCutscene = false;
    private bool taskActive = false;

    public bool TaskActive { get => taskActive; set => taskActive = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueManager == null)
            dialogueManager = FindObjectOfType<DialogueManager>();
            //dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inputTip.SetActive(true);
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputTip.SetActive(false);
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = false;
    }

    private void RunDialogue(bool keyTrigger)
    {
        if (keyTrigger && (inTrigger || inCutscene))
        {
            inputTip.SetActive(false);

            if (!dialogueManager.SentenceFinished)
                dialogueManager.FastPrintLine();
            else
            {
                if (!dialogueLoaded)
                    dialogueLoaded = dialogueManager.LoadDialogue(conversationList[currentConvesation].currentConversation);

                if (dialogueLoaded)
                    dialogueLoaded = dialogueManager.PrintLine();
                if (!dialogueLoaded)
                {
                    conversationList[currentConvesation].EventAfterDialogue?.Invoke();
                    inCutscene = false;
                }
            }
        }
    }

    public void RunDialogue()
    {
        Invoke("HandlePlayerMoveBool", 0.2f);

        inCutscene = true;
        RunDialogue(true);
    }

    public void ChangeConversation()
    {
        if (currentConvesation < conversationList.Count) {
            Debug.Log("Mudando Diálogo");
            currentConvesation++;
            RunDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunDialogue(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0));
    }

    void HandlePlayerMoveBool() {
        player.GetComponent<PlayerController>().canMove = playerCanMove;

        if (!playerCanMove) {
            FindObjectOfType<PlayerController>().rig.velocity = new Vector2(0f, 0f);
        }
    }

}
