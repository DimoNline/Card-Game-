using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckButton : MonoBehaviour
{
    private Player player;
    private int cardToChangeIndex = 0;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void ClickLuck()
    {
        int deltaValue = Random.Range(-2, 10);
        player.cards[cardToChangeIndex].ChangeRandomValue(deltaValue);

        if (cardToChangeIndex < player.cards.Count - 1)
        {
            cardToChangeIndex++;
        }
        else
        {
            cardToChangeIndex = 0;
        }
    }
}
