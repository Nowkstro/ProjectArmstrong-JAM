using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnTerryRightPos : MonoBehaviour {

    public GameObject terry;
    public Transform lootersCampExit;

    void Start() {
        if (ExitLootersCamp.exitedFromLootersCamp) {
            ExitLootersCamp.exitedFromLootersCamp = false;

            terry.transform.position = lootersCampExit.position;
            terry.GetComponent<Animator>().Play("player_idle_LR");
            terry.transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (LoadScenes.exitedFromBunker) {
            LoadScenes.exitedFromBunker = false;

            terry.GetComponent<Animator>().Play("player_idle_LR");
            terry.transform.eulerAngles = new Vector2(0f, 180f);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4) {
            terry.GetComponent<Animator>().Play("player_idle_LR");
            terry.transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void TurnRight() {
        terry.GetComponent<Animator>().Play("player_idle_LR");
        terry.transform.eulerAngles = new Vector2(0f, 0f);
    }

}
