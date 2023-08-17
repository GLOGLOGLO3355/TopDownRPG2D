using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHome : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(113.3f, 69.34f, 0f);
        }
    }
}
