using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private CardUI _cardUI;

    private int _hp;
    private int _mana;

    private int _attack;
    private string _title;


    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _cardUI.hp.SetValue(_hp, value);
            _hp = value;

            if (_hp < 1)
            {
                Remove();
            }
        }
    }

    public int Attack
    {
        get
        {
            return _attack;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _cardUI.attack.SetValue(_attack, value);

            _attack = value;
        }
    }

    public int Mana
    {
        get
        {
            return _mana;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _cardUI.mana.SetValue(_mana, value);

            _mana = value;
        }
    }

    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
            _cardUI.title.text = value;
        }
    }

    private void Awake()
    {
        if (TryGetComponent<CardUI>(out _cardUI) == false)
        {
            Debug.LogError("No CardUI found");
        }
    }

    public void SetData(CardData cardData)
    {
        HP = cardData.hp;
        Attack = cardData.attack;
        Mana = cardData.mana;

        Title = cardData.title;
    }

    public void ChangeRandomValue(int delta)
    {
        int value = Random.Range(0, 3);

        switch (value)
        {
            case 0: HP += delta; break;
            case 1: Attack += delta; break;
            case 2: Mana += delta; break;
        }
    }

    private void Remove()
    {
        Destroy(gameObject, 0.1f);
    }
}
