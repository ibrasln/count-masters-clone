using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private PlayerController playerControllerInParent;
    private MovementToPositionEvent movementToPositionEvent;

    private void Start()
    {
        playerControllerInParent = GetComponentInParent<PlayerController>();
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
    }

    private void Update()
    {
        if (playerControllerInParent.playerState == PlayerState.FIGHTING)
        {
            movementToPositionEvent.CallMovementToPositionEvent(moveSpeed, playerControllerInParent.target.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerControllerInParent.target = collision.gameObject.transform.parent;
            playerControllerInParent.playerState = PlayerState.FIGHTING;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.Restart();
        }
    }
}
