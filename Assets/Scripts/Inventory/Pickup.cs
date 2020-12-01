using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory = default;
    private GameObject pressButton = default;
    public GameObject itemButton = default;

    private bool spawnItemAfterPick = false;

    public Items ID = default;
    public int intID = default;

    private const KeyCode USE_BUTTON = KeyCode.E;
    private bool nearToItem = false;

    void Start() {
        pressButton = GameObject.Find("Backpack Canvas").transform.Find("Press Button").gameObject;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();  
    }

    void Update() {
        if (nearToItem && Input.GetKeyDown(USE_BUTTON))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/sfx_gameplay/item_pegar (normal)", gameObject.transform.position);
            for (int i = 0; i < inventory.slots.Count; i++) 
            {
                if (inventory.isFull[i] == false) 
                {
                    if (spawnItemAfterPick)
                        SpawnItem();
                    
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    if (ID == Items.Scrap)
                        Inventory.scrapAmount++;

                    switch (intID)
                    {
                        case 1:
                            Scrap1.alreadyPickedup = true;
                            break;
                        case 2:
                            Scrap2.alreadyPickedup = true;
                            break;
                        case 3:
                            Scrap3.alreadyPickedup = true;
                            break;
                        case 4:
                            Scrap4.alreadyPickedup = true;
                            break;
                        case 5:
                            Scrap5.alreadyPickedup = true;
                            break;
                    }

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void SpawnItem() {
        ItemInfo ItemInfo = new ItemInfo(transform.position);
        FindObjectOfType<ItemRandomSpawner>().ItemCollectedInfo(ItemInfo);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pressButton.SetActive(true);
            nearToItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pressButton.SetActive(false);
            nearToItem = false;
        }
    }

}
