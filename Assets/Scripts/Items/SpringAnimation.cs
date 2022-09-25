using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnimation : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0 && collision.gameObject.CompareTag("Player"))
        {
            GetComponentInChildren<Animator>().SetTrigger("Active");
        }
    }
}
