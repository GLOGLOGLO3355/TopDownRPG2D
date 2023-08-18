using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Obtener la entrada horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, horizontalInput*-1);
        // Calcular el vector de movimiento
        rb.velocity = transform.up * moveSpeed;
    
    }
}

