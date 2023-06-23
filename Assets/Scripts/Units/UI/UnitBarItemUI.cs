using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitBarItemUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private Button mButOnClick;

    private void Awake() 
    {
        mButOnClick = GetComponent<Button>();
    }

    private void Start() 
    {
        UnitInputController.Instance.OnCancelSelection += UnitBarItemUI_OnCancelSelection;
    }

    private void UnitBarItemUI_OnCancelSelection()
    {
        DeSelect();
    }

    public void Init(Sprite sprite, UnityAction onClickListener)
    {
        // Inicializar el GO
        image.sprite = sprite;
        mButOnClick.onClick.AddListener(onClickListener);
    }

    public void Select()
    {
        GetComponent<Image>().color = Color.red;
    }

    public void DeSelect()
    {
        GetComponent<Image>().color = Color.white;
    }
}
