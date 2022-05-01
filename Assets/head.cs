using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class head : MonoBehaviour
{
    public GameObject left, right, movingPoint, movingButton, player, deadButtons;
    RaycastHit hit1, hit2;
    public float timer1 = 10, timer2 = 25, lvlTimer = 3000, errorTimer, pickUpTimer = 5;
    public TextMesh errorText, actionText;
    public TextMeshPro lvlTimerText;
    public Vector3 accs;
    public List<string> inventory;
    public bool moving, dead;

    private void Update()
    { 
        Vector3 acc = Input.acceleration * 90;

        Input.compass.enabled = true;
        Quaternion rot = Quaternion.Euler(-acc.z, Input.compass.magneticHeading, -acc.x);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, Input.compass.magneticHeading, 0), 0.2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-acc.z, player.transform.rotation.eulerAngles.y, -acc.x), 0.2f);

        movingButton.transform.rotation = Quaternion.Slerp(movingButton.transform.rotation, Quaternion.Euler(80, Input.compass.magneticHeading, 0), 0.2f);
    }

    private void FixedUpdate()
    {
        lvlTimer -= 0.1f;
        double seconds = Math.Round(System.Convert.ToDouble(lvlTimer / 5));
        double minutes = 0;
        while (seconds >= 60)
        {
            minutes += 1;
            seconds -= 60;
        }
        string min = "" + minutes;
        if (minutes < 10) min = "0" + minutes;

        string sec = "" + seconds;
        if (seconds < 10) sec = "0" + seconds;

        lvlTimerText.text = min + ":" + sec;

        Debug.DrawRay(left.transform.position, transform.forward, Color.yellow);
        if (Physics.Raycast(transform.position, transform.forward, out hit1, 20))
        {
            Debug.Log(hit1.collider.name);

            if (moving)
            {
                if (hit1.collider.tag == "floor")
                {
                    movingPoint.SetActive(true);
                    movingButton.SetActive(false);
                    movingPoint.transform.position = hit1.point + transform.up;
                }
                timer2 -= 0.1f;
                actionText.text = Math.Round(timer2 / 5, 1) + "s";
                if (timer2 <= 0)
                {
                    transform.parent.position = movingPoint.transform.position + (Vector3.up * 2);
                    timer2 = 25;
                    moving = false;
                    movingPoint.SetActive(false);
                    movingButton.SetActive(true);
                    movingPoint.transform.position = new Vector3(0, 1, 0);
                }
            }
            else
            {
                if (hit1.collider.tag == "button")
                {
                    timer1 -= 0.1f;
                    actionText.text = Math.Round(timer1 / 5, 1) + "s";
                    if (timer1 <= 0)
                    {
                        hit1.collider.GetComponent<button3d>().pressed();
                        timer1 = 10;
                        actionText.text = "";
                    }
                }
                else
                {
                    timer1 = 10;
                    actionText.text = "";

                    if (hit1.collider.tag == "useable")
                    {
                        hit1.collider.GetComponent<button3d>().pressed();
                    }

                    if (hit1.collider.tag == "item")
                    {
                        pickUpTimer -= 0.1f;
                        actionText.text = "" + Math.Round(pickUpTimer / 5, 1) + "s";
                        if (pickUpTimer <= 0)
                        {
                            errorText.text = "Picked up " + hit1.collider.name + ".";
                            inventory.Add(hit1.collider.name);
                            Destroy(hit1.collider.gameObject);
                            pickUpTimer = 5;
                            actionText.text = "";
                        }
                    }
                    else
                    {
                        pickUpTimer = 5;
                        actionText.text = "";
                    }
                }
            }
        }

        if (errorText.text != "")
        {
            errorTimer += 0.1f;
            if (errorTimer >= 20)
            {
                errorTimer = 0;
                errorText.text = "";
            }
        }
    }
}
