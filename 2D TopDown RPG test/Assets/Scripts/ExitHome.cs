using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHome : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(4.55f, 1.62f, 0f);
        }
    }
}
