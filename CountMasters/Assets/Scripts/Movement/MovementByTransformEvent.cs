using System;
using UnityEngine;

public class MovementByTransformEvent : MonoBehaviour
{
    public event Action<MovementByTransformEvent, MovementByTransformEventArgs> OnMovementByTransform;

    public void CallMovementByTransform(float speed, Vector3 direction)
    {
        OnMovementByTransform?.Invoke(this, new MovementByTransformEventArgs { speed = speed, direction = direction });
    }
}

public class MovementByTransformEventArgs : EventArgs
{
    public float speed;
    public Vector3 direction;
}
