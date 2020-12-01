using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBunkerScene : MonoBehaviour {

    public int sceneIndex;

    public void LoadBunker() {
        LevelLoader.instance.LoadLevel(sceneIndex);
    }

}
