using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementAircraft = new UnityEvent<Vector2>();  

    private void Update()
    {
        GetAirCraftMovement();
    }

    private void GetAirCraftMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementAircraft?.Invoke(movementVector.normalized);
    }
}
