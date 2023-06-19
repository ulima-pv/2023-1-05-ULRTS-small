using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBarItemUI : MonoBehaviour
{
    
    private Image mImage;

    private Button mButton;

    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = transform.Find("Image").GetComponent<Image>();
    }

    public void Init(Sprite mUnitSprite, UnityEngine.Events.UnityAction listener)
    {
        mImage.sprite = mUnitSprite;
        mButton.onClick.AddListener(listener);
    }
}
