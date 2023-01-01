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
    [SerializeField] private float moveToPositionSpeed = 1f;
    [SerializeField] private Transform target;

    [SerializeField] private PlayerState playerState = PlayerState.IDLE;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        ObjectPool.instance.GetPooledObject(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            float randomPositionRange = Random.Range(.25f, .75f);
            GameObject human = ObjectPool.instance.GetPooledObject(0);
            human.transform.position = new Vector3(Random.Range(transform.position.x - randomPositionRange, transform.position.x + randomPositionRange),
                                                   transform.position.y,
                                                   Random.Range(transform.position.z - randomPositionRange, transform.position.z + randomPositionRange));
        }
        HandlePlayerState();
    }

    private void HandlePlayerState()
    {
        switch(playerState)
        {
            case PlayerState.IDLE:
                break;

            case PlayerState.WALKING:
                Movement();
                break;

            case PlayerState.FIGHTING:

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
