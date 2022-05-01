using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStartStop : MonoBehaviour
{
    public Animation[] animStart, animStop;

    public void pressed()
    {
        if (animStart != null) foreach (Animation anim in animStart) anim.Play();
        if (animStop != null) foreach (Animation anim in animStop) anim.Stop();
    }
}
