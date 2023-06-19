using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;

    [SerializeField]
    private UnitTypeSO unitType;

    private NavMeshAgent mAgent;

    public bool Selected { private set; get; } = false;

    private void Awake()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mAgent.speed = unitType.speed;
    }

    public void Select()
    {
        Selected = !Selected;
        selected.SetActive(Selected);
    }

    public void GoToDestination(Vector3 position)
    {
        mAgent.destination = position;
    }

}
