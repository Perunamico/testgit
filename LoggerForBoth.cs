using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Valve.VR;

public class LoggerForBoth : MonoBehaviour
{
    private StreamWriter sw;
    private FileInfo fi;
    private Vector3 LocalStylusPos;
    [System.NonSerialized] public bool isLoggedReal;
    private Vector3 thispos;
    private GameObject movement;
    private HapticIntegration hapticeffect;
    private GameObject grabber;
    private SphereOffset sphereoffset;
    double TruePosx;
    string sendDataPath;
    public bool testflag1 = false;
    //public bool testflag2 = false;
    Vector3 PredictedPos;
    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean trigger;
    [SerializeField] SteamVR_Action_Boolean go;
    [SerializeField] SteamVR_Action_Boolean back;

    int cntact = 0;
    private DateTime date;
    public string filename;

    public enum ExperimentState
    {
        Idle,
        //Reset,
        //Select,
        Finish,
        Check,
        Complete
    }

    public ExperimentState currentState = ExperimentState.Idle;

    void Start()
    {
        InitializeExperiment();
        StartCoroutine(StateMachine());
    }

    void InitializeExperiment()
    {
        isLoggedReal = true;
        date = DateTime.Now;
        grabber = GameObject.Find("Grabber");
        sphereoffset = grabber.GetComponent<SphereOffset>();
        movement = GameObject.Find("Movement");
        hapticeffect = movement.GetComponent<HapticIntegration>();

        string format = "yyyy-MM-dd-HH-mm-ss";
        filename = $"DataChomoro/{date.ToString(format)}.csv";
        fi = new FileInfo(Application.dataPath + "/"+filename);
        //sendfi = new FileInfo(Application.dataPath + "/Unity2Python.csv");
        string csvbegin = $"trueprop,truevisual,reported";
        WriteToFile(csvbegin);
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case ExperimentState.Idle:
                    yield return StartCoroutine(IdleState());
                    break;
                //case ExperimentState.Reset:
                //    yield return StartCoroutine(ResetState());
                //    break;
                //case ExperimentState.Select:
                //    yield return StartCoroutine(SelectState());
                //    break;
                case ExperimentState.Finish:
                    yield return StartCoroutine(FinishState());
                    break;
                //case ExperimentState.Check:
                //   yield return StartCoroutine(CheckState());
                //   break;
                case ExperimentState.Complete:
                    yield break;
            }
        }
    }

    IEnumerator IdleState()
    {

       

        //while (!trigger.GetStateDown(hand) || hapticeffect.isProcessing || isLoggedReal)

        //{
        //    //Debug.Log(trigger.GetStateDown(hand));
        //    if (!trigger.GetStateDown(hand) && !hapticeffect.isProcessing && !isLoggedReal)
        //    {
        //        testflag1 = true;
        //    }

        //    //if (ExperimentData.trialNumLeft == 0)
        //    //{
        //    //    hapticeffect.isFinished = true;
        //    //    Debug.Log("Experiment Complete");

        //    //    //SendFile(filename);
        //    //    yield return null;
        //    //}

        //    yield return null;

        //}
        while (!trigger.GetStateDown(hand) || hapticeffect.isProcessing || isLoggedReal)

        {
            //Debug.Log(trigger.GetStateDown(hand));
            //if (hapticeffect.devices[0].Buttons[0] == 0 && !hapticeffect.isProcessing && !isLoggedReal)
            //{
            //    testflag1 = true;
            //}
            if (!trigger.GetStateDown(hand)  && !hapticeffect.isProcessing && !isLoggedReal)
                {
                    testflag1 = true;
                }

                //if (ExperimentData.trialNumLeft == 0)
                //{
                //    hapticeffect.isFinished = true;
                //    Debug.Log("Experiment Complete");

                //    //SendFile(filename);
                //    yield return null;
                //}

                yield return null;

        }

        LogProprioceptionData();
        currentState = ExperimentState.Finish;
    }

    IEnumerator FinishState()
    {  

        isLoggedReal = true;
        yield return new WaitForSeconds(0.5f);
        currentState = ExperimentState.Idle;
        cntact = cntact + 1;
        if (cntact == 6)
        {
            hapticeffect.isFinished = true;
            Debug.Log("Experiment Complete");

            //SendFile(filename);
            currentState = ExperimentState.Complete;
        }
    }

    

void LogProprioceptionData()
    {
        //isLoggedReal = true;
        testflag1 = false;
        TruePosx = ExperimentData.currentAlpha;
         PredictedPos = hapticeffect.LocalStylusPos;
        Debug.Log(PredictedPos);
        float truesvisual = (160 + ExperimentData.currentAlpha) * ExperimentData.currentGain;
        string str = $"{TruePosx + 160},{truesvisual},{PredictedPos.x + 160}";

        //iteToFile(str);
        WriteToFile(str);
        grabber.transform.localScale = Vector3.zero;
        //thispos = hapticeffect.homepos + sphereoffset.offset + new Vector3(0, 41, 0);
        //this.transform.position = thispos;
    }

    //void LogVisualData()
    //{
    //    isLogged = true;
    //    testflag2 = false;
    //    float truestimuli = (160 + ExperimentData.currentAlpha) * ExperimentData.currentGain;
    //    float ans = this.transform.position.x - thispos.x;
    //    string reportans = $"{ TruePosx + 160}, { PredictedPos.x + 160},{truestimuli}, {ans}";

    //    WriteToFile(reportans);
    //    this.transform.localScale = Vector3.zero;
    //    Debug.Log("Visual Data Logged");
    //}

    void WriteToFile(string content)
    {
        using (sw = fi.AppendText())
        {
            sw.WriteLine(content);
            sw.Flush();
        }
    }
    
}