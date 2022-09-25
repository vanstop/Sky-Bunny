using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsSystem : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;

	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
	}
	
	void Update () {
        anim.SetFloat("YVelocity", rb.velocity.y);
    }

    void LateUpdate()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0 && !Player.Current.wings.activeInHierarchy)
        {
            if (!Player.Current.hasRevive)
            {
                anim.SetTrigger("Dead");
                CameraFollow.Current.gameIsRunning = false;
            }
            else
            {
                Player.Current.Revive();
                Player.Current.hasRevive = false;
            }
        }  
    }

    public void Die()
    {
        anim.SetTrigger("Dead");
        CameraFollow.Current.gameIsRunning = false;
        transform.GetComponentInParent<BoxCollider2D>().enabled = false;
    }

    public void endGame()
    {
        DataController.Current.SaveData();
        if (HUDSystem.Current.points <= 100)
            PlayerPrefs.SetString("wasSeen", "false");
        else
            AdsManager.Current.showAds();
    }
}
