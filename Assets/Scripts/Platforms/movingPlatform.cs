using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    public int direction = 1;
    public float movingSpeed = 200;
	
	void Update () {
        transform.Translate(Vector3.right * direction * Time.deltaTime * movingSpeed);
	}

    public void ChangeDirection()
    {
        direction *= -1;
    }
}
