using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour {

    public WhoIs whoIs;

    public bool isIdleUp = false;
    public bool isIdleDown = false;
    public bool isIdleLR = false;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (isIdleUp) {
            if (whoIs == WhoIs.Mad)
                anim.Play("mad_idle_up");
            if (whoIs == WhoIs.Sonia)
                anim.Play("sonia_idle_up");
        }
        if (isIdleDown) {
            if (whoIs == WhoIs.Mad)
                anim.Play("mad_idle_down");
            if (whoIs == WhoIs.Sonia)
                anim.Play("sonia_idle_down");
        }
        if (isIdleLR) {
            if (whoIs == WhoIs.Mad)
                anim.Play("mad_idle_LR");
            if (whoIs == WhoIs.Sonia)
                anim.Play("sonia_idle_LR");
        }
    }

}

public enum WhoIs {
    Mad,
    Sonia
}
