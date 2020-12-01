using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject pauseMenu = default;

    private bool opened = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !opened) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            opened = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && opened) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;

            opened = false;
        }
    }

}
