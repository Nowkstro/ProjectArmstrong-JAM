using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public GameObject item = null;
    private Transform player = null;
    public Items ID = default;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void DropItem() {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 1);

        if (item.GetComponent<Pickup>().ID == Items.Scrap)
            Inventory.scrapAmount--;

        Instantiate(item, playerPos, Quaternion.identity);
    }

}
