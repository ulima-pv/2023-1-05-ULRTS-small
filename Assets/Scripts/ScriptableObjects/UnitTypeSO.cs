using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit")]
public class UnitTypeSO : ScriptableObject
{
    public new string name;
    public Transform prefab;
    public float speed;
    public float actionRange;
    public Sprite image;
    public float restTime;
}
