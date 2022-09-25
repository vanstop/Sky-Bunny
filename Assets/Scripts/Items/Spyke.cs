using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyke : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && collision.relativeVelocity.y <= 0)
        {
            collision.gameObject.GetComponentInChildren<PlayerAnimationsSystem>().Die();
        }
    }
}
