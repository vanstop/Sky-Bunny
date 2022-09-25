using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {

    public static Jetpack Current;

    public int jetpackSpeed = 1000;

    void Awake()
    {
        Current = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!Player.Current.jetpack.activeInHierarchy)
            { 
                Player.Current.isJetPacked = true;
                gameObject.SetActive(false);
            }
        }
    }
}
