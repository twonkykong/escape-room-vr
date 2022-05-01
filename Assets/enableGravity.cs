using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableGravity : MonoBehaviour
{
    public GameObject obj;

    public void pressed()
    {
        obj.AddComponent<Rigidbody>();
    }
}
