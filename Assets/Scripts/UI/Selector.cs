using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private GameObject selector = default;
    private bool isSelected = false;
    private void OnMouseDown()
    {
        isSelected = !isSelected;
        Debug.Log("Personagem clicado.");
        selector.SetActive(isSelected);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
