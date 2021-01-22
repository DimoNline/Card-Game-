using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI title;

    [SerializeField] private Image mainArt;

    [SerializeField] public CardValueUI hp;
    [SerializeField] public CardValueUI attack;

    [SerializeField] public CardValueUI mana;


    private void Start()
    {
        StartCoroutine(LoadArt("https://picsum.photos", mainArt, (int)mainArt.rectTransform.rect.width, (int)mainArt.rectTransform.rect.height));
    }

    private IEnumerator LoadArt(string url, Image image, int width, int height)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GetURL(url, width, height));
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Rect rect = new Rect(0, 0, width, height);
            Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
            image.sprite = sprite;
        }
    }

    private string GetURL(string url, int width, int height)
    {
        //https://picsum.photos/width/height
        return url + "/" + width + "/" + height;
    }

}
