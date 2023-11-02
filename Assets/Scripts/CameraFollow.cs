using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] float yOffset;
    [SerializeField] float zOffset;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset,
            playerTransform.position.z + zOffset);
    }
}
