using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public static Mushroom Current;

    void Awake()
    {
        Current = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (Player.Current.transform.localScale.x == 1)
            {
                Player.Current.isGrowed = true;
                gameObject.SetActive(false);
            }
        }
    }
}
