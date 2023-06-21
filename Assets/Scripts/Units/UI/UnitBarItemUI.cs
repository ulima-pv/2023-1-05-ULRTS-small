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
    
    public void Init(Sprite sprite, UnityAction onClickListener)
    {
        // Inicializar el GO
        image.sprite = sprite;
        mButOnClick.onClick.AddListener(onClickListener);
    }
}
