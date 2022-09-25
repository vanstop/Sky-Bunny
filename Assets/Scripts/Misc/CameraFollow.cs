using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow Current;

    [SerializeField] Transform target;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject background;

    public bool gameIsRunning = true;

    void Awake()
    {
        Current = this;
    }

    void LateUpdate () {

        if (gameIsRunning)
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newPos;
                newPos = new Vector3(transform.position.x, target.position.y -20f, 0);
                gameOverCanvas.transform.position = newPos;
            }
        }
        else
        {
            Vector3 newPos = new Vector3(transform.position.x, gameOverCanvas.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, .03f);
        }
		
	}
}
