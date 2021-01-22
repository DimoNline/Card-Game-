using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject cardsParent;
    [SerializeField] private GameObject cardPrefab;

    private List<CardData> cardDatas;
    private Player player;

    private const string cardDataFolder = "CardsData";

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        LoadCardsData();
        PutCards();
    }

    private void LoadCardsData()
    {
        cardDatas = new List<CardData>();
        cardDatas = Resources.LoadAll<CardData>(cardDataFolder).ToList();
    }
    private CardData GetRandomCardData()
    {
        return cardDatas[Random.Range(0, cardDatas.Count)];
    }

    private void PutCards()
    {
        int numberOfCards = Random.Range(4, 7);
        for (int i = 0; i <= numberOfCards; i++)
        {
            Card newCard = Instantiate(cardPrefab, cardsParent.transform).GetComponent<Card>();
            newCard.SetData(GetRandomCardData());
            player.AddCard(newCard);
        }
    }
}
