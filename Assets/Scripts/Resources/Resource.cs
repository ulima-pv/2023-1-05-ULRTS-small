using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private ResourceTypeSO resourceType;

    private int mCurrentAmount;

    private void Awake()
    {
        mCurrentAmount = resourceType.maxAmount;
    }

    public void CollectResource(int quantity)
    {
        if (mCurrentAmount > 0)
        {
            mCurrentAmount -= quantity;
            Debug.Log($"{resourceType.name} Current Amount: {mCurrentAmount}");
        }
        else
        {
            Debug.Log("Se acabo el recurso");
            Destroy(gameObject);
        }
    }
}
