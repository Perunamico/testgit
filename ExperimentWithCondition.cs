using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentWithCondition : MonoBehaviour
{
    /// <summary>
    /// 実験の流れを管理するStateMachine
    /// </summary>
    public StateMachine Flow;
    /// <summary>
    /// 実験の条件を管理するStateMachine
    /// </summary>
    public StateMachine Condition;

    private void OnValidate()
    {
        Flow.InitializeStates();
        Condition.InitializeStates();
    }
    private void FixedUpdate()
    {
        Flow.Update(Time.fixedDeltaTime);
        Condition.Update(Time.fixedDeltaTime);
    }

    private int m_windowId = 0;
    private Rect m_windowRect = new Rect(0, 0, 200, 300);
    private void OnGUI()
    {
        m_windowRect = GUI.Window(m_windowId, m_windowRect, (id) =>
        {
            Flow.ShowGUI(id);
            GUILayout.Label(""); // 改行
            Condition.ShowGUI(id);
            GUI.DragWindow();
        }, name);
    }
}