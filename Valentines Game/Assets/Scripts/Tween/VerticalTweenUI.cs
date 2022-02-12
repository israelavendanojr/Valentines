using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTweenUI : MonoBehaviour
{
    [SerializeField] float enterTo, exitTo;
    [SerializeField] float duration, delay;
    [SerializeField] LeanTweenType inType, outType;
    public void Enter()
    {
        LeanTween.moveLocalY(gameObject, enterTo, duration).setDelay(delay).setEase(outType);
    }

    public void Exit()
    {
        LeanTween.moveLocalY(gameObject, exitTo, duration).setDelay(delay).setEase(inType);
    }
}
