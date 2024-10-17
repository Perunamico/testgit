using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTransition : Transition
{
    [SerializeField]
    private string m_stateFrom;
    [SerializeField]
    private string m_stateTo;
    [SerializeField]
    private float m_timeMax = 10f;

    public override string GetStateFrom() => m_stateFrom;
    public override string GetStateTo() => m_stateTo;
    public override bool IsTriggered(State s) => GetRemainedTime(s) <= 0f;
    /// <summary>
    /// 残り時間を取得する
    /// </summary>
    /// <param name="s"></param>
    public float GetRemainedTime(State s) => m_timeMax - s.CurrentTime;
}
