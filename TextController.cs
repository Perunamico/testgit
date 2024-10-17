using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] GameObject proptext;
    [SerializeField] GameObject visualtext;
    private GameObject visualsphere;
    private LoggerForBoth loggerforboth;
    private GameObject movement;
    private HapticIntegration hapticintegration;
    // Start is called before the first frame update
    void Start()
    {
        visualsphere = GameObject.Find("VisualSphere");
        loggerforboth = visualsphere.GetComponent<LoggerForBoth>();
        movement = GameObject.Find("Movement");
        hapticintegration = movement.GetComponent<HapticIntegration>();
        proptext.transform.localScale=new Vector3(0f,0f,0f);
        visualtext.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("flag1 is"+loggerforboth.testflag1);
        //Debug.Log("flag2 is"+loggerforboth.testflag2);
        if (loggerforboth.testflag1)
        {
            proptext.transform.localScale = new Vector3(5f, 5f, 5f);
        }
        //if (loggerforboth.testflag2)
        //{
        //    visualtext.transform.localScale = new Vector3(5f, 5f, 5f);
        //}
        if (!loggerforboth.testflag1)
        {
            proptext.transform.localScale = new Vector3(0f, 0f, 0f);
        }
        if (hapticintegration.isFinished)
        {
            visualtext.transform.localScale = new Vector3(5f, 5f, 5f);
        }    //if (!loggerforboth.testflag2 )
        
        //    visualtext.transform.localScale = new Vector3(0f, 0f, 0f);
        //}

    }
}
