using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Building")]
public class BuildingTypeSO : ScriptableObject
{
    public new string name;
    public Transform prefab;
    public Sprite sprite;
    public float constructionTime;
    public List<BuildingAmountsSO> neededResources;
}
