using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfoBarUI : MonoBehaviour
{
    [SerializeField]
    private List<ResourceTypeSO> resourceTypeList;

    [SerializeField]
    private Transform resourceInfoBarUIPrefab;

    [SerializeField]
    private float offset = 100f;

    private void Start() 
    {
        float index = 0f;
        foreach(var resourceTypeSO in resourceTypeList)
        {
            var resourceInfoItem = Instantiate(resourceInfoBarUIPrefab, transform);
            resourceInfoItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                index * offset,
                0f
            );
            resourceInfoItem.GetComponent<ResourceInfoUI>().Init(
                resourceTypeSO.name,
                resourceTypeSO.image
            );
            index++;
        }   
    }
}
