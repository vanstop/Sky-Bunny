using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantExitScreen : MonoBehaviour
{

    [SerializeField] bool Horizontal;
    [SerializeField] bool Vertical;

    [SerializeField] Vector3 newPos;

    void Update()
    {
        newPos = Camera.main.WorldToViewportPoint(transform.position);

        if (Horizontal)
        {
            if (newPos.x > 0.875f)
            {
                newPos.x = 0.875f;
                GetComponent<movingPlatform>().ChangeDirection();
            }
            else if (newPos.x < 0.125f)
            {
                newPos.x = 0.125f;
                GetComponent<movingPlatform>().ChangeDirection();
            }
        }

        if (Vertical)
        {
            if (newPos.y > 0.125f)
            {
                newPos.y = 0.125f;
                GetComponent<movingPlatform>().ChangeDirection();
            }
            else if (newPos.y < 0.875f)
            {
                newPos.y = 0.875f;
                GetComponent<movingPlatform>().ChangeDirection();
            }
        }
        transform.position = Camera.main.ViewportToWorldPoint(newPos);
    }
}