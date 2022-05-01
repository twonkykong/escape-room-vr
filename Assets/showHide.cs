using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHide : MonoBehaviour
{
    public GameObject[] show, hide;

    public void pressed()
    {
        if (show != null) foreach (GameObject obj in show) obj.SetActive(true);
        if (hide != null) foreach (GameObject obj in hide) obj.SetActive(false);
    }
}
