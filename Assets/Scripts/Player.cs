using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public List<Card> cards;

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

}
