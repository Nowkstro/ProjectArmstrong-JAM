using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipFixArea : MonoBehaviour {

    public UnityEvent AfterFixEvent;

    public float fixRange = 0.5f;
    private bool shipFixed = false;
    private bool insideArea = default;
    private bool pressButtonDeactivated = false;
    
    public LayerMask playerLayerMask = default;
    public GameObject fixHud = default;
    public GameObject pressButton = default;
    private Inventory inventory = default;

    void Start() {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update() {
        HandleSpaceshipFixHud();

        // Checking if any object with "Player" layer is inside the fix area
        Collider2D collider = Physics2D.OverlapCircle(transform.position, fixRange, playerLayerMask);

        if (collider != null) {
            insideArea = true;
        }
        else {
            insideArea = false;
        }
    }

    void HandleSpaceshipFixHud() {
        if (insideArea && !shipFixed) {
            pressButtonDeactivated = false;

            fixHud.SetActive(true);
            pressButton.SetActive(true);

            // Checking for input
            if (Input.GetKeyDown(KeyCode.E))
                CheckIfEnough();
        } else {
            fixHud.SetActive(false);

            if (!pressButtonDeactivated) {
                pressButtonDeactivated = true;
                pressButton.SetActive(false);
            }
        }
    }

    void CheckIfEnough() {
        if (Inventory.scrapAmount >= TextUpdate.maxAmount) {
            shipFixed = true;

            // Removing items from inventory
            for (int i = 0; i < TextUpdate.maxAmount; i++) {
                if (inventory.slots[i].transform.GetChild(0).gameObject.GetComponent<Drop>().ID == Items.Scrap) {
                    Destroy(inventory.slots[i].transform.GetChild(0).gameObject);
                    Inventory.scrapAmount--;
                }
            }

            // TODO - Call some function to fix the spaceship
            AfterFixEvent?.Invoke();
        } else
            return;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fixRange);
    }

}
