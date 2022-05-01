using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingButton : MonoBehaviour
{
    public GameObject player;

    public void pressed()
    {
        player.GetComponent<head>().moving = true;
    }
}
