using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogContanier : MonoBehaviour
{
    // OBS: Não esquecer de definir no inspector de SpriteRender o 'Draw Mode' como 'Sliced'
    private SpriteRenderer backgroundSpriteRender;
    private TextMeshPro textMeshPro;
    [SerializeField] private Vector2 padding = new Vector2(.5f, .2f);

    // Start is called before the first frame update
    void Awake()
    {
        backgroundSpriteRender = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        Setup("Hello World!\nOi, eu sou o Goku!");
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate(); //Previnir que os textos não sejam renderizados.
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        backgroundSpriteRender.size = textSize + padding;
        backgroundSpriteRender.transform.localPosition = new Vector3(backgroundSpriteRender.size.x / 2f, 0f);
    }
}
