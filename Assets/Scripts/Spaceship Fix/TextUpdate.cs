using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

    private Text textMesh;
    private Inventory inventory;

    public static int maxAmount = 5;
    private int currentAmount = default;

    void Start() {
        textMesh = GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();
    }

    void Update() {
        currentAmount = Inventory.scrapAmount;
        textMesh.text = String.Format("{0}/{1}", currentAmount.ToString(), maxAmount.ToString());
    }

}
