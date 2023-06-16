using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelection : MonoBehaviour
{
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
                // Hubo colision
                
                /*Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null)
                {
                    UnitManager.Instance.SelectUnit(unit);
                }*/
                if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                {
                    UnitManager.Instance.SelectUnit(unit);
                }
            }
        }
    }
}
