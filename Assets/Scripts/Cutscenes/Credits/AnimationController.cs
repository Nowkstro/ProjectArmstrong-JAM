using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public GameObject creditsContainer;

    void Start() {
        Invoke("PassCredits", 2.3f);
    }

    void PassCredits() {
        creditsContainer.SetActive(true);
    }

}
