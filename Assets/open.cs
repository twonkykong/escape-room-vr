using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    public Animation anim;
    public AnimationClip animClip;

    public void pressed()
    {
        anim.Play(animClip.name);
        gameObject.tag = "Untagged";
    }
}
