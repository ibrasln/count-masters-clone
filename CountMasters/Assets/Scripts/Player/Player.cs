using UnityEngine;

[RequireComponent(typeof(MovementToPosition))]
[RequireComponent(typeof(MovementToPositionEvent))]
[RequireComponent(typeof(MovementByTransform))]
[RequireComponent(typeof(MovementByTransformEvent))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public MovementToPositionEvent movementToPositionEvent;
    [HideInInspector] public MovementByTransformEvent movementByTransformEvent;

    private void Awake()
    {
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
        movementByTransformEvent = GetComponent<MovementByTransformEvent>();
    }
}
