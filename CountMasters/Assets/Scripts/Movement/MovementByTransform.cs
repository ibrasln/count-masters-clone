using UnityEngine;

[RequireComponent(typeof(MovementByTransformEvent))]
[DisallowMultipleComponent]
public class MovementByTransform : MonoBehaviour
{
    private MovementByTransformEvent movementByTransformEvent;

    private void Awake()
    {
        movementByTransformEvent = GetComponent<MovementByTransformEvent>();
    }

    private void OnEnable()
    {
        movementByTransformEvent.OnMovementByTransform += MovementByTransformEvent_OnMovementByTransform;
    }

    private void OnDisable()
    {
        movementByTransformEvent.OnMovementByTransform -= MovementByTransformEvent_OnMovementByTransform;
    }

    private void MovementByTransformEvent_OnMovementByTransform(MovementByTransformEvent movementByTransformEvent, MovementByTransformEventArgs movementByTransformEventArgs)
    {
        MoveObject(movementByTransformEventArgs.speed , movementByTransformEventArgs.direction);
    }

    private void MoveObject(float speed, Vector3 direction)
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
