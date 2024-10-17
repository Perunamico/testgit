using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    /// <summary>
    /// このTransitionが遷移条件を満たしている
    /// </summary>
    /// <returns></returns>
    public abstract bool IsTriggered(State state);
    /// <summary>
    /// 遷移元のState
    /// </summary>
    /// <returns></returns>
    public abstract string GetStateFrom();
    /// <summary>
    /// 遷移先のState
    /// </summary>
    /// <returns></returns>
    public abstract string GetStateTo();
}