using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBarUI : MonoBehaviour
{
    [SerializeField]
    private List<UnitTypeSO> unitTypeList;

    [SerializeField]
    private Transform unitBarItemUIPrefab;

    [SerializeField]
    private float offset = 100f;

    private void Start()
    {
        float index = 0f;
        foreach (var unitTypeSO in unitTypeList)
        {
            var unitItemUI = Instantiate(unitBarItemUIPrefab, transform);
            unitItemUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                index * offset,
                0f
            );
            unitItemUI.GetComponent<UnitBarItemUI>().Init(unitTypeSO.image, () =>
            {
                UnitManager.Instance.SelectUnitToSpawn(unitTypeSO);
            });
            index++;
        }
    }
}
