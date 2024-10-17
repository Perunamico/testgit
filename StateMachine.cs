using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class StateMachine
{
    [Header("現在のStateの番号")]
    [SerializeField]
    private int m_currentStateIndex;
    /// <summary>
    /// 現在のStateの番号
    /// </summary>
    public int CurrentStateIndex
    {
        get => m_currentStateIndex;
        set => SetCurrentState(value);
    }
    /// <summary>
    /// 現在のState
    /// </summary>
    public State CurrentState => States[m_currentStateIndex];
    /// <summary>
    /// このStateMachineのStateの集合
    /// </summary>
    public List<State> States;
    [SerializeReference]
    public List<Transition> Transitions;

    public void InitializeStates()
    {
        for (int i = 0; i < States.Count; i++)
        {
            States[i].SetStateMachine(this);
        }
    }
    /// <summary>
    /// 現在のStateのOnUpdateを毎フレーム呼び続ける
    /// </summary>
    public void Update(float deltaTime = 0.02f)
    {
        CurrentState.OnUpdate(deltaTime);
        for (int i = 0; i < Transitions.Count; i++)
        {
            if (Transitions[i].GetStateFrom() == CurrentState.Label && Transitions[i].IsTriggered(CurrentState))
            {
                SetCurrentState(Transitions[i].GetStateTo());
                break;
            }
        }
    }
    public void SetCurrentState(int index)
    {
        // m_currentStateIndexが[0, m_states.Count)に収まるように代入する
        if (index < 0)
        {
            index = States.Count - 1;
        }
        else if (States.Count <= index)
        {
            index = 0;
        }

        // 現在のStateをExitする
        States[m_currentStateIndex].OnExit();

        // 現在のStateを更新してEnterする
        m_currentStateIndex = index;
        States[m_currentStateIndex].OnEnter();
    }
    public void SetCurrentState(State state)
    {
        for (int i = 0; i < States.Count; i++)
        {
            if (States[i] == state)
            {
                SetCurrentState(i);
                return;
            }
        }
        Debug.LogWarning($"StateMachine: This StateMachine does not have {state.GetType().ToString()}!");
    }
    public void SetCurrentState(string label)
    {
        for (int i = 0; i < States.Count; i++)
        {
            if (States[i].Label == label)
            {
                SetCurrentState(i);
                return;
            }
        }
        Debug.LogWarning($"StateMachine: This StateMachine does not have any states whose label is {label}!");
    }
    /// <summary>
    /// IMGUIを実装する
    /// </summary>
    /// <param name="windowId"></param>
    public void ShowGUI(int windowId)
    {
        // 遷移用ボタンの表示
        GUILayout.Label($"Current State: {CurrentState}");
        GUILayout.BeginHorizontal();
        for (int i = 0; i < States.Count; i++)
        {
            if (GUILayout.Button($"{States[i]}"))
            {
                SetCurrentState(i);
            }

            // 3つごとに改行する
            if (i % 3 == 2)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
            }
        }
        GUILayout.EndHorizontal();

        // 時間の表示
        GUILayout.Label($"Time: {CurrentState.CurrentTime:0.00}");
    }
}