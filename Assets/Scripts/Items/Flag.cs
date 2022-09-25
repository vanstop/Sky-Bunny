using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    public float wind;
    public float timeToChange;
    public int windRange;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        InvokeRepeating("changeWind", timeToChange, timeToChange);
    }

    void Update()
    {

        Player.Current.wind = wind/100;

        anim.SetFloat("Wind", wind);
        if (wind < 0)
            transform.localScale = new Vector3(-1, 1);
        else if (wind > 0)
            transform.localScale = new Vector3(1, 1);
    }

    public void changeWind()
    {
        wind = Random.Range(-windRange, windRange);
    }
}
