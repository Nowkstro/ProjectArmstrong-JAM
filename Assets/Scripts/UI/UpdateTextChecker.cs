using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextChecker : MonoBehaviour
{
    [SerializeField] Resources resouce = Resources.Scrap;
    private enum Resources
    {
        Scrap,
        Food,
        ShipFixPercentage,
    }

    //event EventHandler eventAttribute;
    // Start is called before the first frame update
    void Awake()
    {
        switch (resouce)
        {
            case Resources.ShipFixPercentage:
                GameResources.OnFixShipPercentageChanged += delegate (object sender, EventArgs e)
                {
                    UpdateText(sender.ToString() + "%");
                }; 
                break;
            case Resources.Food:
                GameResources.OnFoodPercentageChanged += delegate (object sender, EventArgs e)
                {

                };
                break;
        }
    }

    private void UpdateText(string text)
    {
        GetComponent<TextMeshProUGUI>().text = text;
    }
}
