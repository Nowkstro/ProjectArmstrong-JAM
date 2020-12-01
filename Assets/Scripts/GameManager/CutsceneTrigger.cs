using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    private PlayableDirector cutscene;
    public bool playOnTrigger;
    public bool isIntro = false;
    public UnityEvent OnPlay;
    public UnityEvent OnStop;

    private bool playerIsTrigger;
    private bool alreadyPlayed;

    void Start() {
        cutscene = GetComponent<PlayableDirector>();
        
        if (isIntro) {
            cutscene.playOnAwake = false;
            PlayCutscene();
        }
    }

    private void Update()
    {
        if (playerIsTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                PlayCutscene();
            }
        }
    }

    public void PlayCutscene()
    {
        if (alreadyPlayed)
            return;
        OnPlay?.Invoke();
        alreadyPlayed = true;
        cutscene.Play();
        Invoke("FinishCutscene", (float)cutscene.duration);
    }

    void FinishCutscene()
    {
        Debug.Log("Encerrando cutscene.");
        OnStop?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsTrigger = true;
            if (playOnTrigger)
            {
                PlayCutscene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsTrigger = false;
        }
    }
}
