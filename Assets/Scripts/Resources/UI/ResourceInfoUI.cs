using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceInfoUI : MonoBehaviour
{
    private Image mImage;
    private TextMeshProUGUI mText;

    private void Awake() 
    {
        mImage = transform.Find("Image").GetComponent<Image>();
        mText = transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();    
    }

    public void Init(string resourceName, Sprite resourceSprite)
    {
        mImage.sprite = resourceSprite;
        mText.text = resourceName;
    }

}
