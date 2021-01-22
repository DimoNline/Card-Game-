using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData_", menuName = "Card Configuration")]

public class CardData : ScriptableObject
{
    public string title;
    public string descrption;

    public int hp;
    public int mana;
    public int attack;
}
