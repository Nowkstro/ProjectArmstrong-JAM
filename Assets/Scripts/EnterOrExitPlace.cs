using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterOrExitPlace : MonoBehaviour {

    public int sceneBuildIndex;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") 
            SceneManager.LoadScene(sceneBuildIndex);
    }

}
