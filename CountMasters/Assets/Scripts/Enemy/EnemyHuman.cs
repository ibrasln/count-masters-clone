using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private EnemyController enemyControllerInParent;
    private MovementToPositionEvent movementToPositionEvent;

    private void Awake()
    {
        enemyControllerInParent = GetComponentInParent<EnemyController>(); 
    }

    private void Start()
    {
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
    }

    private void Update()
    {
        if (enemyControllerInParent.isPlayerTouched) movementToPositionEvent.CallMovementToPositionEvent(moveSpeed, enemyControllerInParent.target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyControllerInParent.isPlayerTouched = true;
            enemyControllerInParent.target = collision.gameObject.transform.parent;
            enemyControllerInParent.enemyState = EnemyState.FIGHTING;
            Destroy(gameObject);
        }
    }
}
