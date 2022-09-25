using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour {

    public static Player Current;
    public GameObject jetpack;
    public GameObject wings;

    public bool hasRevive = false;

    [SerializeField] int bigSize;
    [SerializeField] float bigSizeTime;
    [SerializeField] float movementSpeed;


    Rigidbody2D rb;
    float movement = 0f;

    public float jetpackTime = 5;

    public bool isJetPacked = false;
    public bool isGrowed = false;

    public float wind;

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isJetPacked)
        {
            isJetPacked = false;
            jetpack.SetActive(true);
            Invoke("TurnOffJetpack", jetpackTime);
        }

        if (jetpack.activeInHierarchy)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jetpack.Current.jetpackSpeed * Time.deltaTime);
        }

        if(wings.activeInHierarchy && rb.velocity.y <= 0)
        {
            wings.SetActive(false);
        }

        if (isGrowed)
        {
            isGrowed = false;
            transform.localScale = new Vector3(bigSize, bigSize, bigSize);
            Invoke("BackToNormalSize", bigSizeTime);
        }
    }

    void FixedUpdate()
    {
        movement = (wind + Input.GetAxis("Horizontal") + Input.acceleration.x * 4) * movementSpeed * Time.deltaTime;
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void TurnOffJetpack()
    {
        jetpack.SetActive(false);
    }

    public void Revive()
    {
        rb.velocity = new Vector2(rb.velocity.x, Wings.Current.wingSpeed * Time.deltaTime);
        wings.SetActive(true);
    }

    public void BackToNormalSize()
    {
        transform.localScale = Vector3.one;
    }
}
