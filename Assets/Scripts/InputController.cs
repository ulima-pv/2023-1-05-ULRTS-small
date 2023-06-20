using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class InputController : MonoBehaviour
{
    public enum SpawningState
    {
        None, Unit, Building
    }

    public static InputController Instance { get; private set; }

    public SpawningState CurrentSpawningState = SpawningState.None;

    private void Awake()
    {
        Instance = this;
    }

    private void OnSelection(InputValue value)
    {
        if (value.isPressed && !EventSystem.current.IsPointerOverGameObject())
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
                // Hubo colision

                /*Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null)
                {
                    UnitManager.Instance.SelectUnit(unit);
                }*/
                if (CurrentSpawningState == SpawningState.None)
                {
                    if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                    {
                        UnitManager.Instance.SelectUnit(unit);
                    }else
                    {
                        UnitManager.Instance.DeselectAllUnits();
                    }

                }
                else if (CurrentSpawningState == SpawningState.Unit)
                {
                    UnitManager.Instance.SpawnUnit(hit.point);
                }

            }
        }
    }

    private void OnCancel(InputValue value)
    {
        if (value.isPressed)
        {
            if (CurrentSpawningState != SpawningState.None)
            {
                CurrentSpawningState = SpawningState.None;
            }else
            {
                UnitManager.Instance.DeselectAllUnits();
            }
            
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
                UnitManager.Instance.MoveSelectedUnits(hit.point);
                Debug.Log("must move");
            }
        }
    }
}
