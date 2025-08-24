using System;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    private Animation _animationExplodion;

    public void PlayExplodeAnimation()
    {
        _animationExplodion.Play();
    }
}
