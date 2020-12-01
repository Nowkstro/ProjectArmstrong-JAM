using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    //[SerializeField] private Renderer renderer;
    [SerializeField] private GameObject tooltip = default;

    // Start is called before the first frame update

    private void Start()
    {
        //renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        tooltip.SetActive(true);
        tooltip.transform.position = new Vector3(transform.position.x + 3.5f, transform.position.y, transform.position.z);
        var charStats = GetComponent<CharacterStats>();
        tooltip.GetComponent<Tooltip>().ShowCharacterStats(charStats.CharName, charStats.Life, charStats.Strenght);
    }

    private void OnMouseExit()
    {
        tooltip.SetActive(false);
        // Esconder o tooltip
    }
}
