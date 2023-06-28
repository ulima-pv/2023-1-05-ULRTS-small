using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAction : MonoBehaviour
{
    public bool IsActive = false;
    public int AmountToCollect = 1;

    public Resource resource;

    private float mTimer;
    private Unit mUnit;
    private UnitTypeSO mUnitType;

    private void Start() 
    {
        mUnit = GetComponent<Unit>();
        mUnitType = mUnit.GetUnitTypeSO();
        mTimer = 0f;
    }

    private void Update() 
    {
        if (IsActive)
        {
            if (mTimer <= 0f)
            {
                if (resource != null)
                {
                    resource.FarmResource(AmountToCollect);
                    mTimer = mUnitType.coolDownTime;
                }else
                {
                    mUnit.GetComponent<CollectAction>().IsActive = false;
                    
                }
            }else
            {
                mTimer -= Time.deltaTime;
            }
            
        }
        
    }
}
