using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour {

    public static Wings Current;

    public int wingSpeed = 750;

    void Awake()
    {
        Current = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!Player.Current.wings.activeInHierarchy && !Player.Current.hasRevive)
            {
                Player.Current.hasRevive = true;
                gameObject.SetActive(false);
            }
        }
    }

}
