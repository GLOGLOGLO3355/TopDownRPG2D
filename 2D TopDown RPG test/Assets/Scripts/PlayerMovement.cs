using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject enemy;
    private bool canWalk = true;

    public string SceneStarshipFight;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void StopPlayer(Vector2 enemyPosition)
    {
        rb.velocity = Vector2.zero;
        canWalk = false;
        anim.SetBool("isWalkingDown", false);
        anim.SetBool("isWalkingSide", false);
        anim.SetBool("isWalkingUp", false);
        float difx = transform.position.x - enemyPosition.x;
        float dify = transform.position.y - enemyPosition.y;
        if(Mathf.Abs(difx)<Mathf.Abs(dify))
        {
            if(dify>0)
            {
                anim.SetBool("isStandingDown",true);
            }
            else
            {
                anim.SetBool("isStandingUp", true);
            }
        } else
        {
            anim.SetBool("isStandingSide", true);
            if(difx>0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            } else
            {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

    public void EnemyAttack(GameObject enemy)
    {
        SceneManager.LoadScene("Starshipfight");
    }
    private void Update()
    {
        // Obtener la entrada horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        if (canWalk)
        {
            rb.velocity = new Vector2(horizontalInput, verticalInput) * moveSpeed;


            if (verticalInput == 0 && horizontalInput == 0)
            {
                anim.SetBool("isWalkingSide", false);
                anim.SetBool("isWalkingUp", false);
                anim.SetBool("isWalkingDown", false);
            }

            if (horizontalInput < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            if (horizontalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (horizontalInput != 0)
            {
                anim.SetBool("isWalkingSide", true);
                anim.SetBool("isWalkingUp", false);
                anim.SetBool("isWalkingDown", false);
            }
            else
            {
                anim.SetBool("isWalkingSide", false);
                if (verticalInput < 0)
                {
                    anim.SetBool("isWalkingUp", false);
                    anim.SetBool("isWalkingDown", true);
                }
                else if (verticalInput > 0)
                {
                    anim.SetBool("isWalkingDown", false);
                    anim.SetBool("isWalkingUp", true);
                }

            }

        }
    }
}
