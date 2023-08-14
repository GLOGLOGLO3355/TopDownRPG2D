using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        // Obtener la entrada horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        rb.velocity = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        if (horizontalInput < 0){
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        if (horizontalInput > 0){
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (horizontalInput != 0) {
            anim.SetBool("isWalkingSide", true);
            anim.SetBool("isWalkingUp", false);
            anim.SetBool("isWalkingDown", false);
        }
        else {
            if (verticalInput<0){
                anim.SetBool("isWalkingUp", false);
                anim.SetBool("isWalkingDown", true);
            }
            else if (verticalInput > 0){
                anim.SetBool("isWalkingDown", false);
                anim.SetBool("isWalkingUp", true);
            }
            else
            {
                anim.SetBool("isWalkingSide", false);
                anim.SetBool("isWalkingUp", false);
                anim.SetBool("isWalkingDown", false);
            }
        }

    }
}

