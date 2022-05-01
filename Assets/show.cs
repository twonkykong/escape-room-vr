using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{
    public GameObject objShow;
    float start;

    public void pressed()
    {
        if (objShow != null) objShow.SetActive(true);
    }

    void FixedUpdate()
    {
        if (objShow == null) return;

        if (objShow.activeInHierarchy) start += 0.1f;
        if (start >= 25)
        {
            start = 0;
            objShow.SetActive(false);
        }
    }
}
