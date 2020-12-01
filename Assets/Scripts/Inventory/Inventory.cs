using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Transform inventory;

    [HideInInspector]
    public static int scrapAmount = default;

    [HideInInspector] 
    public List<GameObject> slots = new List<GameObject>();
    
    // To find out which slot is free
    [HideInInspector] 
    public bool[] isFull = null;

    public GameObject itemButton;

    void Awake() {
        int qntSlots = 0;
        
        // Adding each GameObject slot to the list
        foreach(Transform slot in inventory)
            if (slot.CompareTag("Slot")) 
            {
                slots.Add(slot.GetChild(0).gameObject);
                qntSlots++;
            }

        isFull = new bool[qntSlots];

        // Defining the index of each slot
        for (int i = 0; i < slots.Count; i++) {
            slots[i].GetComponent<Slot>().i = i;
        }
    }

    void Start() {
        for (int i = 0; i < Inventory.scrapAmount; i++) 
        {
            isFull[i] = true;
            Instantiate(itemButton, slots[i].transform, false);
        }
    }

}

public enum Items {
    Scrap = 1
}
