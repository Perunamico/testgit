using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class State
{
    /// <summary>
    /// このStateを管理するクラス
    /// </summary>
    private StateMachine m_stateMachine;

    [Header("状態の名前")]
    [SerializeField]
    private string m_label = "New State";
    public string Label => m_label;
    public override string ToString() => Label;

    [System.Serializable]
    public class EventState : UnityEvent<State>
    {

    }

    #region Action
    [Header("このStateに入った時に呼ばれる")]
    //public UnityEvent<State> OnStateEnter = new UnityEvent<State>();
    public EventState OnStateEnter = new EventState();
    [Header("このStateにいる間常に呼ばれる")]
    //public UnityEvent<State> OnStateUpdate = new UnityEvent<State>();
    public EventState OnStateUpdate = new EventState();
    [Header("このStateから出た時に呼ばれる")]
    //public UnityEvent<State> OnStateExit = new UnityEvent<State>();
    public EventState OnStateExit = new EventState();
    #endregion
    #region Time Management
    [Header("遷移からの経過時間")]
    [SerializeField]
    private float m_currentTime = 0f;
    /// <summary>
    /// 遷移からの経過時間
    /// </summary>
    public float CurrentTime => m_currentTime;
    #endregion

    /// <summary>
    /// このStateを管理するStateMachineを設定する
    /// </summary>
    public void SetStateMachine(StateMachine stateMachine)
    {
        m_stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        OnStateEnter.Invoke(this);

        m_currentTime = 0f;
    }
    public void OnUpdate(float deltaTime = 0.02f)
    {
        OnStateUpdate.Invoke(this);

        // カウントダウンを進める
        m_currentTime += deltaTime;
    }
    public void OnExit()
    {
        OnStateExit.Invoke(this);

        m_currentTime = 0f;
    }
}