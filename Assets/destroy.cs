using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject obj;

    public void pressed()
    {
        Destroy(obj);
    }
}
