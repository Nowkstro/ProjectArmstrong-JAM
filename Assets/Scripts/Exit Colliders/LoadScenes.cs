using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {

    public int sceneIndexToLoad = default;

    public static bool exitedFromBunker = false;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {

            // Bunker
            if (SceneManager.GetActiveScene().buildIndex == 4) {
                TPCorrectPlace.noMoreCutscene = true;
                exitedFromBunker = true;
            }
            
            LevelLoader.instance.LoadLevel(sceneIndexToLoad);
        }
    }

}
