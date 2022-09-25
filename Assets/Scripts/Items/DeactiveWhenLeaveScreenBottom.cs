using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveWhenLeaveScreenBottom : MonoBehaviour
{
    void Update()
    {
        bool isOnScreen = Camera.main.WorldToScreenPoint(transform.position).y > 1;
        if (!isOnScreen)
        {
            gameObject.SetActive(false);

            if (transform.childCount > 1)
            {
                for (int i = 1; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.parent = null;
                }
            }
        }
    }
}
