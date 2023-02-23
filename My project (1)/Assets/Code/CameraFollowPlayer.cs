using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerShip>()?.transform;
        if (player == null)
        {
            Debug.LogError("No PlayerShip found in the scene. Disabling CameraFollowPlayer script.");
            enabled = false;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
