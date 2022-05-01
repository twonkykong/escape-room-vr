using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPoint : MonoBehaviour
{
    public GameObject[] points;

    public void pressed()
    {
        GameObject.FindWithTag("Player").transform.position = transform.position + transform.up * 2;
        foreach (GameObject point in points) point.SetActive(true);
        gameObject.SetActive(false);
    }
}
