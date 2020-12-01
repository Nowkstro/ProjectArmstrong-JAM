using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTFix : MonoBehaviour {

    void Start() {
        Invoke("PlaySound", 0.5f);
    }

    void PlaySound() {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bity/BityTurningOn", gameObject.transform.position);
    }

}
