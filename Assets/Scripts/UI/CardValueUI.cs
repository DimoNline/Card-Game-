using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardValueUI : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI text;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetValue(int currentValue, int newValue)
    {
        int delta = 1;
        if (newValue < currentValue)
        {
            delta = -1;
        }

        if (currentValue != newValue)
        {
            StartCoroutine(IncrementValue(currentValue, newValue, delta));
        }
        else
        {
            text.text = newValue.ToString();
        }
    }


    private IEnumerator IncrementValue(int currentValue, int targetValue, int delta)
    {
        yield return new WaitForSeconds(0.1f);

        currentValue += delta;
        text.text = currentValue.ToString();

        if (currentValue != targetValue)
        {

            StartCoroutine(IncrementValue(currentValue, targetValue, delta));
        }
    }
}
