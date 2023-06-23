using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : MonoBehaviour
{
    public bool IsActive;

    private NavMeshAgent mAgent;

    private Unit mUnit;

    private void Awake() 
    {
        mAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() 
    {
        mUnit = GetComponent<Unit>();
        UnitTypeSO unitType = mUnit.GetUnitTypeSO();
        Debug.Log(unitType);
        mAgent.speed = unitType.speed;
    }

    public void Move(Vector3 position)
    {
        mAgent.destination = position;
    }
}
