using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputTip : MonoBehaviour
{
    [SerializeField] GameObject player = default;

    [Range(0f, 1f)] [SerializeField] private float offsetX = .3f;
    [Range(0f, 1f)] [SerializeField] private float offsetY = .4f;
    public TextMeshProUGUI inputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x + offsetX, player.transform.position.y + offsetY);
    }
}
