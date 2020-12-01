using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTerryRightPlace : MonoBehaviour {

    public GameObject terry;

    void Start() {
        if (SceneManager.GetActiveScene().buildIndex == 6) {
            terry.GetComponent<Animator>().Play("player_idle_down");
        }
    }

    void TurnDown() {
        terry.GetComponent<Animator>().Play("player_idle_down");
    }

}
