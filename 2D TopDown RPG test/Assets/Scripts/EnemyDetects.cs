using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetects : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public float moveSpeed = 2.0f;
    public float stoppingDistance = 2.0f;
    private Rigidbody2D rb;
    private bool isFollowingPlayer = false;

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
            anim.SetBool("walk",true);
            isFollowingPlayer= true;
        }
    }

    private void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            if (directionToPlayer.magnitude > stoppingDistance)
            {
                rb.velocity = directionToPlayer.normalized * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetBool("walk", false);
            }
        }
    }
}
