using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShip: MonoBehaviour
{
    public Transform player;
    public PlayerShipMovement playerMovement;
    public float Algo;
    public Vector3 offset;

    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Algo);
        transform.position = smoothedPosition;
    }
}
