using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementToPosition))]
[RequireComponent(typeof(MovementToPositionEvent))]
[RequireComponent(typeof(PlayerController))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public MovementToPositionEvent movementToPositionEvent;

    private void Awake()
    {
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
    }
}
