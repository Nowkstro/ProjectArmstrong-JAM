﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLootersCamp : MonoBehaviour {

    public int levelIndex;

    public static bool exitedFromLootersCamp = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            exitedFromLootersCamp = true;
            LevelLoader.instance.LoadLevel(levelIndex);
        }
    }

}
