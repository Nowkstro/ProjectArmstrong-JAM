using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueCutsceneTrigger : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] List<string> conversationList = new List<string>();

    private int currentConvesation = 0;
    private bool dialogueLoaded = false;
    private bool inDialogue = false;
    private bool triggered = false;


    // Start is called before the first frame update
    void Start()
    {
        if (dialogueManager == null)
            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    public void RunDialogue()
    {
        triggered = true;
        Debug.Log("Tecla pressionada.");
        Debug.Log("path = " + conversationList[0] + ", dialogueLoaded = " + dialogueLoaded + ",\ncurrentPath = " + currentConvesation + ", inDialogue = " + inDialogue + ", dialogManager.SentenceFinished = " + dialogueManager.SentenceFinished);

        if (!dialogueManager.SentenceFinished)
            dialogueManager.FastPrintLine();
        else
        {
            if (!dialogueLoaded)
                dialogueLoaded = dialogueManager.LoadDialogue(conversationList[currentConvesation]);

            if (dialogueLoaded)
                dialogueLoaded = dialogueManager.PrintLine();
        }
    }

    public void ChangeConversation()
    {
        if (currentConvesation < conversationList.Count)
            currentConvesation++;
        triggered = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && triggered) RunDialogue();
    }

}
