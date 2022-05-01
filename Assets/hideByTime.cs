using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideByTime : MonoBehaviour
{
    float start;
    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy) start += 0.1f;
        if (start >= 25)
        {
            start = 0;
            gameObject.SetActive(false);
        }
    }
}
