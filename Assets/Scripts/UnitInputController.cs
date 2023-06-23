using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public enum SpawningState
{
    Selection, Spawn
}


public class UnitInputController : MonoBehaviour
{
    public SpawningState CurrentSpawningState = SpawningState.Selection;

    public event UnityAction OnCancelSelection;

    public static UnitInputController Instance {get; private set;}

    private void Awake() 
    {
        Instance = this;
    }

    private void OnSelection(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));


            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                if (CurrentSpawningState == SpawningState.Selection)
                {
                    if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                    {
                        UnitManager.Instance.SelectUnit(unit);
                    }
                }else
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        UnitManager.Instance.SpawnUnit(hit.point);
                    }
                    
                }
            }
        }
    }

    private void OnCancel(InputValue value)
    {
        if (value.isPressed)
        {
            CurrentSpawningState = SpawningState.Selection;
            OnCancelSelection?.Invoke();
            UnitManager.Instance.DeselectAll();
        }
    }

    private void OnMoveUnit(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));


            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                // Mover las unidades
                UnitManager.Instance.MoveUnits(hit.point);
            }
        }
    }
}
