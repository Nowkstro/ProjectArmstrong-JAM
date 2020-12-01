using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AliciaHouseIntro : MonoBehaviour {

    private PlayableDirector cutscene;
    private static bool alreadyPlayed = false;

    void Start() {
        cutscene = GetComponent<PlayableDirector>();

        if (!alreadyPlayed) {
            PlayCutscene();
        }
    }

    void PlayCutscene() {
        alreadyPlayed = true;
        cutscene.Play();
    }

}
