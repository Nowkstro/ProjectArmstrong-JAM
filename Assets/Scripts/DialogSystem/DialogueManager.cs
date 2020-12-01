using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DialogueTrigger;

public class DialogueManager : MonoBehaviour
{
    private const string DIALOGUE_FOLDER = "Dialogues/";
    private const string FLAT_IMAGES_FOLDER = "FlatImages/";

    private const string opaqueColor = "#505050";
    private const string lightColor = "#FFFFFF";

    /*private event EventHandler OnDialogueFinished;*/

    [SerializeField] private TextMeshProUGUI textDisplay = default;
    [SerializeField] private TextMeshProUGUI charNameDisplay = default; 
    [SerializeField] private GameObject dialogueContainer = default;
    [SerializeField] private List<Image> characterPortraits = new List<Image>(2);
    [Range(0f, .2f)] [SerializeField] private float textDelay = .1f;
    private JsonData dialogue;
    private int index;
    private string leftCharacter = "";
    private string rightCharacter = "";

    private bool inDialogue = false;
    private bool sentenceFinished = true;

    public bool SentenceFinished { get => sentenceFinished; }

    private void Awake()
    {
        if(dialogueContainer == null)
            dialogueContainer = GameObject.Find("DialogueContainer");
    }

    public bool LoadDialogue(string path)
    {
        //Debug.Log("LoadDialogue():\ninDialogue = " + inDialogue);
        if (!inDialogue)
        {
            //Debug.Log("Diálogo ativo.");
            index = 0;
            var jsonTextFile = Resources.Load<TextAsset>(DIALOGUE_FOLDER + path);
            leftCharacter = "";
            rightCharacter = "";
            characterPortraits[0].enabled = false;
            characterPortraits[1].enabled = false;

            if (jsonTextFile != null)
            {
                dialogue = JsonMapper.ToObject(jsonTextFile.text);

                for (int i = 0; i < dialogue.Count; i++)
                {
                    if (leftCharacter != "" && rightCharacter != "")
                        break;

                    JsonData line = dialogue[i];
                    string speaker = "";
                    foreach (JsonData key in line.Keys)
                    {
                        speaker = key.ToString();
                        //Debug.Log("speaker = " + speaker);
                    }

                    if (speaker != "" && speaker != "EOD")
                    {
                        Sprite characterPortrait = Resources.Load<Sprite>(FLAT_IMAGES_FOLDER + speaker);
                        if (leftCharacter == "")
                        {
                            characterPortraits[0].sprite = characterPortrait;
                            characterPortraits[0].enabled = true;
                            leftCharacter = speaker;
                        }
                        else if (rightCharacter == "" && speaker != leftCharacter)
                        {
                            characterPortraits[1].sprite = characterPortrait;
                            characterPortraits[1].enabled = true;
                            rightCharacter = speaker;
                        }
                    }
                }

                inDialogue = true;
                dialogueContainer.SetActive(true);
                return true;
            }
        }
        return false;
    }

    public bool PrintLine()
    {
        if (inDialogue)
        {
            string speaker = "";
            JsonData line = dialogue[index];
            string dialogueText = line[0].ToString();
            //Debug.Log("dialogueText = " + dialogueText);

            if (dialogueText == "EOD")
            {
                inDialogue = false;
                textDisplay.text = "";
                charNameDisplay.text = "";
                dialogueContainer.SetActive(false);
                
                return false;
            }

            foreach(JsonData key in line.Keys)
            {
                speaker = key.ToString();
            }
            if(speaker == leftCharacter)
            {
                changeCharacterPortrait(0, lightColor);
                changeCharacterPortrait(1, opaqueColor);
            } else
            {
                changeCharacterPortrait(0, opaqueColor);
                changeCharacterPortrait(1, lightColor);
            }
            
            charNameDisplay.text = speaker;
            textDisplay.text = "";
            sentenceFinished = false;
            StartCoroutine(PrintLine(dialogueText));
        }

        return true;
    }

    private void changeCharacterPortrait(int position, string colorHex)
    {
        characterPortraits[position].color = ChangePortraitColor(colorHex);
    }

    public void FastPrintLine()
    {
        if (!SentenceFinished) {
            JsonData line = dialogue[index];
            string dialogueText = line[0].ToString();
            textDisplay.text = dialogueText;
            index++;
            sentenceFinished = true;
            StopAllCoroutines();
        }
        
    }

    private Color ChangePortraitColor(string colorHex)
    {
        Color newCol;
        ColorUtility.TryParseHtmlString(colorHex, out newCol);
        return newCol;
    }

    private IEnumerator PrintLine(string text)
    {
        for(int i = 0; i < text.Length; i++)
        {
            textDisplay.text += text[i];
            yield return new WaitForSeconds(textDelay);
        }
        sentenceFinished = true;
        index++;
    }

    public void ResetDialogue()
    {
        index = 0;
    }

    public void ShowLastDialogue()
    {
        index = dialogue.Count - 2;
        //inDialogue = true;
    }

    public void ChangeToNextConversation(DialogueTrigger currentTrigger)
    {
        currentTrigger.ChangeConversation();
    }

    // Start is called before the first frame update
    void Start()
    {
        //LoadDialogue("Conversation1");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
            PrintLine();*/
    }

    public void LetPlayerMove() {
        FindObjectOfType<PlayerController>().canMove = true;
    }
}
