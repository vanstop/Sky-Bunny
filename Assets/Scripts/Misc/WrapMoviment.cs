using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapMoviment : MonoBehaviour {

    [SerializeField] bool Horizontal;
    [SerializeField] bool Vertical;

    [SerializeField] Vector3 newPos;

    void Start () {
		
	}
	
	void Update () {
        newPos = Camera.main.WorldToViewportPoint(transform.position);

        if (Horizontal)
        {
            if(newPos.x > 1)
            {
                newPos.x = 0;
            }
            else if(newPos.x < 0)
            {
                newPos.x = 1;
            }
        }

        if (Vertical)
        {
            if (newPos.y > 1)
            {
                newPos.y = 0;
            }
            else if (newPos.y < 0)
            {
                newPos.y = 1;
            }
        }
        transform.position = Camera.main.ViewportToWorldPoint(newPos);
	}
}
