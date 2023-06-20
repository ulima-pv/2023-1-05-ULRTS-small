using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;

    [SerializeField]
    private UnitTypeSO unitType;

    private MoveAction mMoveAction;

    public bool Selected { private set; get; } = false;

    private void Awake()
    {
        mMoveAction = GetComponent<MoveAction>();
    }

    public void Select()
    {
        Selected = !Selected;
        selected.SetActive(Selected);
    }

    public void GoToDestination(Vector3 position)
    {
        mMoveAction.Move(position);
    }

    public void Collect(Resource resource)
    {
        if (TryGetComponent<CollectAction>(out CollectAction action))
        {
            mMoveAction.IsActive = false;
            action.resource= resource;
            action.IsActive= true;
        }

    }

    public void Attack()
    {

    }


    public UnitTypeSO GetUnitTypeSO()
    {
        return unitType;
    }

}
