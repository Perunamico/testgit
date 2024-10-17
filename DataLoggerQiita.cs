using System.IO; 
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using UnityEngine;

public class DataLoggerQiita : MonoBehaviour
{
    private StreamWriter sw;
    private FileInfo fi;

    private Vector3 LocalStylusPos;
    [System.NonSerialized] public bool isLogged;
    GameObject movement;
    HapticEffect hapticeffect;

    private DateTime date;
    // Use this for initialization
    void Start()
    {
        isLogged = true;
        date = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        string str;
        string format = "yyyy-MM-dd-HH-mm-ss";
        string filename = "/Data/" + date.ToString(format) + ".csv";
        //string filename = "/Data/" + ExperimentData.fileName + date.ToString(format) + ".csv";
        fi = new FileInfo(Application.dataPath + filename);
        //Debug.Log(Application.dataPath);
        movement = GameObject.Find("Movement");
        hapticeffect = movement.GetComponent<HapticEffect>();

        // Determine if the stylus is in the "zone". 

        if (!hapticeffect.isFinished&&!hapticeffect.isProcessing &&!isLogged &&Input.GetKeyDown(KeyCode.Space))
        {
            double TruePosx = ExperimentData.currentAlpha;
            double TruePosy = 0;
            double TruePosz = 0;
            Vector3 PredictedPos = hapticeffect.LocalStylusPos;
            //Vector3 TruePos = hapticeffect.Position;
            str = "TruePos is " + (TruePosx+160) + "," + (TruePosy) + "," + (TruePosz) + "," + "PredictedPos is " + (PredictedPos.x+160) + "," + (PredictedPos.y-41) + "," + (PredictedPos.z);
            sw = fi.AppendText();
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            Debug.Log(isLogged);
            Debug.Log("Log");    
            isLogged = true;
            if (ExperimentData.trialNumLeft == 0)
            {
                hapticeffect.isFinished = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("space");
        }

    }
        //str = this.gameObject + "," + (transform.position.x) + "," + (transform.position.y) + "," + (transform.position.z) + "," + transform.rotation.x + "," + transform.rotation.y + "," + transform.rotation.z + "," + transform.rotation.w;
        //sw = fi.AppendText();
        //sw.WriteLine(str);
        //sw.Flush();
        //sw.Close();
    
}
