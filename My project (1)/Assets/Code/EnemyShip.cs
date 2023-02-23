using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    private Transform target;
    public bool canFireAtPlayer;

    private void Start()
    {
        target = FindObjectOfType<PlayerShip>()?.transform;
        if (target == null)
        {
            Debug.LogError("No PlayerShip found in the scene. Disabling EnemyShip script.");
            enabled = false;
        }
    }

    private void FlyToPlayer()
    {
        Vector2 directionToFace = (target.position - transform.position).normalized;
        transform.up = directionToFace;
        Thrust();
    }

    private void Update()
    {
        FlyToPlayer();

        if (canFireAtPlayer)
        {
            FireProjectile();
        }
    }
}
