using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MoveAction : MonoBehaviour
{
    [SerializeField]
    private Transform raycastPoint;

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
        mAgent.speed = mUnit.GetUnitTypeSO().speed;
    }

    private void Update()
    {
        if (IsActive)
        {
            if (IsAResourceNear(out Resource resource))
            {
                mAgent.isStopped= true;
                Debug.Log("Must start collect action");
                mUnit.Collect(resource);
            }

            Debug.DrawRay(raycastPoint.position, raycastPoint.forward * mUnit.GetUnitTypeSO().actionRange);
        }
    }

    public void Move(Vector3 position)
    {
        IsActive = true;
        mAgent.isStopped = false;
        mAgent.destination = position;
    }

    private bool IsAResourceNear(out Resource resource)
    {
        if (Physics.Raycast(
            raycastPoint.position,
            raycastPoint.forward,
            out RaycastHit hit,
            mUnit.GetUnitTypeSO().actionRange,
            LayerMask.GetMask("Tree")
        ))
        {
            resource = hit.collider.GetComponent<Resource>();
            return true;
        }
        resource = null;
        return false;
    }
}
