using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLight : MonoBehaviour {

    public GameObject lightSrc;
    private static bool alreadyDestroyed = false;

    void Start() {
        if (alreadyDestroyed) {
            Destroy(lightSrc);
        }
    }

    public void DestroyLight() {
        Destroy(lightSrc);
        alreadyDestroyed = true;
    }

}
