using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeKeeper : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro m_label;
    [SerializeField]
    private TimeTransition m_timeTransition;

    public void SetRemainedTime(State state)
    {
        var time = m_timeTransition.GetRemainedTime(state);
        m_label.text = $"{Mathf.Ceil(time):0} sec";
        //m_label.text = "Debug";
    }
}
