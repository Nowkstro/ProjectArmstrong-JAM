using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string charName;
    [SerializeField] private int life;
    [SerializeField] private int strenght;
    [SerializeField] private int intelligence;
    [SerializeField] private int moveSpeed = 5;

    public int Life { get => life; set => life = value; }
    public int Strenght { get => strenght; set => strenght = value; }
    public string CharName { get => charName; set => charName = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
