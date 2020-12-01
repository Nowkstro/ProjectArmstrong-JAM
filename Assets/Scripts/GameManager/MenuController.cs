using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject guide;
    public GameObject mainMenu;

    public void NewGame() {
        LevelLoader.instance.LoadNextLevel();
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenGuide() {
        if (!guide.activeSelf) {
            mainMenu.SetActive(false);
            guide.SetActive(true);
        }
        else {
            mainMenu.SetActive(true);
            guide.SetActive(false); 
        }
    }

}
