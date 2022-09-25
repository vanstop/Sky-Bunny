using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{

    public float jumpForce = 10f;
    [SerializeField] bool OneTimePlatform = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * rb.transform.localScale.x * jumpForce * Time.deltaTime;
                if (OneTimePlatform)
                    gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * rb.transform.localScale.x * jumpForce * Time.deltaTime;
                if (OneTimePlatform)
                    gameObject.SetActive(false);
            }
        }
    }
}