using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAction : MonoBehaviour
{
    public bool IsActive { get; set; }
    public int AmountToCollect = 1;

    public Resource resource { get; set; }

    private Unit mUnit;
    private float mTimer;


    private void Awake()
    {
        mUnit = GetComponent<Unit>();
        mTimer = 0f;
    }

    private void Update()
    {
        if (IsActive) 
        {
            if (resource!= null)
            {
                if (mTimer > 0)
                {
                    mTimer -= Time.deltaTime;
                }else
                {
                    resource.CollectResource(AmountToCollect);
                    mTimer = mUnit.GetUnitTypeSO().restTime;
                }
                
            }else
            {
                Debug.Log("Ya no hay recurso");
                IsActive= false;
            }
        }   
    }
}
