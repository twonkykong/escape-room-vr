using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMaterial : MonoBehaviour
{
    public GameObject obj;
    public Material mat;

    public void pressed()
    {
        obj.GetComponent<Renderer>().material = mat;
    }
}
