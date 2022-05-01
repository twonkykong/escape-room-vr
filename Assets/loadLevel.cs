using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadLevel : MonoBehaviour
{
    public string level;

    public void pressed()
    {
        Application.LoadLevel(level);
    }
}
