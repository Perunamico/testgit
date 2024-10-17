using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTransition : Transition
{
    [SerializeField]
    private string m_stateFrom;
    [SerializeField]
    private string m_stateTo;
    [SerializeField]
    private int m_count;
    public int Count => m_count;
    [SerializeField]
    private int m_countMax = 10;

    public override string GetStateFrom() => m_stateFrom;
    public override string GetStateTo() => m_stateTo;
    public override bool IsTriggered(State s) => m_countMax <= m_count;

    // 今回の場合は試行回数を数えたいので，
    // 1つずつ足していく方法以外でm_countの値を変更することは
    // できないようにした．すると不具合が減る．
    public void Incliment() => m_count++;
}
