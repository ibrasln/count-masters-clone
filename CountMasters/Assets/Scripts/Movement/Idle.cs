using UnityEngine;

[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Idle : MonoBehaviour
{
    private IdleEvent idleEvent;
    private Rigidbody rB;

    private void Awake()
    {
        idleEvent = GetComponent<IdleEvent>();
        rB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        idleEvent.OnIdle += IdleEvent_OnIdle;
    }

    private void OnDisable()
    {
        idleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    private void IdleEvent_OnIdle(IdleEvent idleEvent)
    {
        MoveRigidbody();
    }

    private void MoveRigidbody()
    {
        rB.velocity = Vector2.zero;
    }
}
