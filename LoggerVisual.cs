using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;
using System.Text;

public class LoggerVisual : MonoBehaviour
{
    private StreamWriter sw;
    private FileInfo fi;

    private Vector3 LocalStylusPos;
    [System.NonSerialized] public bool isLogged;
    GameObject movement;
    HapticVisual hapticvisual;
    public string participantname;
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
        string filename = "/Data/" + participantname + "_Visual_" +date.ToString(format) + ".csv";
        //string filename = "/Data/" + ExperimentData.fileName + date.ToString(format) + ".csv";
        fi = new FileInfo(Application.dataPath + filename);
        //Debug.Log(Application.dataPath);
        movement = GameObject.Find("Movement");
        hapticvisual = movement.GetComponent<HapticVisual>();

        // Determine if the stylus is in the "zone". 

        //if (!isLogged && Input.GetKeyDown(KeyCode.Space))
        //{
        //    double TruePosx = ExperimentData.currentAlpha;
        //    double TruePosy = 0;
        //    double TruePosz = 0;
        //    Vector3 PredictedPos = hapticvisual.LocalStylusPos;
        //    //Vector3 TruePos = hapticeffect.Position;
        //    str = "TruePos is " + (TruePosx) + "," + (TruePosy) + "," + (TruePosz) + "," + "PredictedPos is " + (PredictedPos.x) + "," + (PredictedPos.y) + "," + (PredictedPos.z);
        //    sw = fi.AppendText();
        //    sw.WriteLine(str);
        //    sw.Flush();
        //    Debug.Log(isLogged);
        //    sw.Close();
        //    Debug.Log("Log");
        //    isLogged = true;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    Debug.Log("space");
        //}

    }
    //str = this.gameObject + "," + (transform.position.x) + "," + (transform.position.y) + "," + (transform.position.z) + "," + transform.rotation.x + "," + transform.rotation.y + "," + transform.rotation.z + "," + transform.rotation.w;
    //sw = fi.AppendText();
    //sw.WriteLine(str);
    //sw.Flush();
    //sw.Close();

}

