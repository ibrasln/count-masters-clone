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
    [SerializeField] private float moveSpeedInFight = 1f;

    public PlayerState playerState = PlayerState.IDLE;
    public Transform target;

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        HandlePlayerState();
    }

    private void HandlePlayerState()
    {
        switch(playerState)
        {
            case PlayerState.IDLE:
                if (GameManager.instance.isGameStarted) playerState = PlayerState.WALKING;
                break;

            case PlayerState.WALKING:
                Movement();
                break;

            case PlayerState.FIGHTING:
                if(target.childCount <= 0)
                {
                    playerState = PlayerState.WALKING;
                }
                break;
        }
    }

    private void Movement()
    {
        player.movementByTransformEvent.CallMovementByTransform(moveSpeed, Vector3.forward);
        
        float h = Input.GetAxisRaw("Horizontal");

        if (h != 0f)
        {
            player.movementByTransformEvent.CallMovementByTransform(moveSpeed, new(h, 0, 0));
        }
    }
}
