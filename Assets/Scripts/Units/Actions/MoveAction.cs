using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : MonoBehaviour
{
    public bool IsActive = true;

    [SerializeField]
    private float colliderRadius = 2f;

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

    private void Update() 
    {
        
        if (IsActive)
        {
            if (IsResourceNear(out Resource resource))
            {
                
                mAgent.isStopped = true;
                mUnit.Collect(resource);
            }
        }
    }

    private bool IsResourceNear(out Resource resource)
    {
        resource = null;

        var colliders = Physics.OverlapSphere(
            transform.position,
            colliderRadius,
            LayerMask.GetMask("Resource"));

        if (colliders.Length > 0)
        {
            return colliders[0].TryGetComponent<Resource>(out resource);
        }else {
            return false;
        }
    }

    public void Move(Vector3 position)
    {
        mAgent.destination = position;
    }
}
