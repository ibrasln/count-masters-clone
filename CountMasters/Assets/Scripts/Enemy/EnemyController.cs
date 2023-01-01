using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[DisallowMultipleComponent]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public EnemyState enemyState = EnemyState.IDLE;

    public bool isPlayerTouched;
    public Transform target;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float randomPositionRange = 1.75f;
            transform.GetChild(i).position = new(Random.Range(transform.position.x - randomPositionRange, transform.position.x + randomPositionRange),
                                                 transform.position.y,
                                                 Random.Range(transform.position.z - randomPositionRange, transform.position.z + randomPositionRange));
        }
    }

    private void Update()
    {
        HandleEnemyState();
    }

    private void HandleEnemyState()
    {
        switch (enemyState)
        {
            case EnemyState.IDLE:
                enemy.idleEvent.CallIdleEvent();
                break;

            case EnemyState.FIGHTING:
                break;
        }
    }
}
