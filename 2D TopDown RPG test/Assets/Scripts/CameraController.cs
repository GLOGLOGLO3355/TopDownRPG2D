using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public PlayerMovement playerMovement;
    public float Algo;
    public Vector3 offset;

    void Update()
    {
            Vector3 desiredPosition = player.position + offset;
            //desiredPosition.y = transform.position.y;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,Algo);
            transform.position = smoothedPosition;
    }
}
