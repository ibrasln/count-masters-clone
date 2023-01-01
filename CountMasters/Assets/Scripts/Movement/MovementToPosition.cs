using UnityEngine;

[RequireComponent(typeof(MovementToPositionEvent))]
[DisallowMultipleComponent]
public class MovementToPosition : MonoBehaviour
{
    private MovementToPositionEvent movementToPositionEvent;

    private void Awake()
    {
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
    }

    private void OnEnable()
    {
        movementToPositionEvent.OnMovementToPosition += MovementToPositionEvent_OnMovementToPosition;
    }

    private void OnDisable()
    {
        movementToPositionEvent.OnMovementToPosition -= MovementToPositionEvent_OnMovementToPosition;
    }

    private void MovementToPositionEvent_OnMovementToPosition(MovementToPositionEvent movementToPositionEvent, MovementToPositionEventArgs movementToPositionEventArgs)
    {
        MoveObject(movementToPositionEventArgs.speed, movementToPositionEventArgs.targetPosition);
    }

    private void MoveObject(float speed, Vector3 targetPosition)
    {
        Vector3 unitVector = Vector3.Normalize(targetPosition - transform.position);
        transform.Translate(speed * Time.deltaTime *  unitVector);
    }
}
