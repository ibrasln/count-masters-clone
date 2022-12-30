using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{

    #region Header MOVEMENT
    [Space(5)]
    [Header("MOVEMENT")]
    #endregion
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform target;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        player.movementToPositionEvent.CallMovementToPositionEvent(moveSpeed, target.position);
    }
}
