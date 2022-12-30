using System;
using UnityEngine;

public class MovementToPositionEvent : MonoBehaviour
{
    public event Action<MovementToPositionEvent, MovementToPositionEventArgs> OnMovementToPosition;

    public void CallMovementToPositionEvent(float speed, Vector3 targetPosition)
    {
        OnMovementToPosition?.Invoke(this, new MovementToPositionEventArgs { speed = speed, targetPosition = targetPosition });
    }
}

public class MovementToPositionEventArgs : EventArgs
{
    public float speed;
    public Vector3 targetPosition;
}
