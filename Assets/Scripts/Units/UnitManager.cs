using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { private set; get; }
    private List<Unit> mSelectedUnits = new List<Unit>();

    private UnitTypeSO mUnitTypeToSpawn = null;

    public int unitSelected = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectUnit(Unit unit)
    {
        if (!unit.Selected)
        {
            mSelectedUnits.Add(unit);
        }else 
        {
            mSelectedUnits.Remove(unit);
        }
        
        unit.Select();
        unitSelected = mSelectedUnits.Count;
    }

    public void SelectUnitToSpawn(UnitTypeSO unitType)
    {
        mUnitTypeToSpawn = unitType;
        InputController.Instance.CurrentSpawningState = InputController.SpawningState.Unit;
    }

    public void SpawnUnit(Vector3 position)
    {
        if (mUnitTypeToSpawn != null)
        {
            Instantiate(mUnitTypeToSpawn.prefab, position, Quaternion.identity);
        }
    }

    public void MoveSelectedUnits(Vector3 destination)
    {
        foreach (var unit in mSelectedUnits)
        {
            unit.GoToDestination(destination);
        }
    }

    public void DeselectAllUnits()
    {
        foreach (var unit in mSelectedUnits)
        {
            unit.Select();
        }
        unitSelected = 0;
        mSelectedUnits.Clear();
    }
}
