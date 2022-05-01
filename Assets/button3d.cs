using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button3d : MonoBehaviour
{
    public string[] scriptNames;
    public bool needSomething, lookat;
    public string something;

    private void Update()
    {
        if (lookat) transform.LookAt(GameObject.FindWithTag("Player").transform);
    }
    public void pressed()
    {
        if (needSomething)
        {
            if (GameObject.FindWithTag("Player").GetComponentInChildren<head>().inventory.Contains(something))
            {
                foreach (string scriptName in scriptNames) GetComponent(scriptName).GetType().GetMethod("pressed").Invoke(GetComponent(scriptName), new object[0]);
            }
            else GameObject.FindWithTag("Player").GetComponentInChildren<head>().errorText.text = "Can't do that.";
        }
        else foreach (string scriptName in scriptNames) GetComponent(scriptName).GetType().GetMethod("pressed").Invoke(GetComponent(scriptName), new object[0]);
    }
}
