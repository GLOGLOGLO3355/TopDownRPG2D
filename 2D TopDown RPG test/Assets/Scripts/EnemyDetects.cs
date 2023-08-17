using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetects : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject player;
    private Animator anim;
    public float moveSpeed = 2.0f;
    public float stoppingDistance = 2.0f;
    private Rigidbody2D rb;
    public bool isFollowingPlayer = false;

    // Start is called before the first frame update
    private void Start()
    {
        anim= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isFollowingPlayer=true;
            anim.SetBool("isWalkingDown", false);
            anim.SetBool("isWalkingSide", false);
            anim.SetBool("isWalkingUp", false);
            float difx = transform.position.x - player.transform.position.x;
            float dify = transform.position.y - player.transform.position.y;
            if (Mathf.Abs(difx) < Mathf.Abs(dify))
            {
                if (dify > 0)
                {
                    anim.SetBool("isWalkingDown", true);
                }
                else
                {
                    anim.SetBool("isWalkingUp", true);
                }
            }
            else
            {
                anim.SetBool("isWalkingSide", true);
                if (difx > 0)
                {
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }
    }

    private void Update()
    {
        if (isFollowingPlayer)
        {
            playerMovement.StopPlayer(transform.position);
            Vector3 directionToPlayer = player.transform.position - transform.position;
            if (directionToPlayer.magnitude > stoppingDistance)
            {
                rb.velocity = directionToPlayer.normalized * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetBool("isWalkingDown", false);
                anim.SetBool("isWalkingSide", false);
                anim.SetBool("isWalkingUp", false);
                playerMovement.EnemyAttack(gameObject);

            }
        }
    }
}
