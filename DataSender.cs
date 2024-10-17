using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSender : MonoBehaviour
{
    int count = 0;
    string sendDataPath;
    string recieveDataPath;
    private GameObject movement;
    private HapticIntegration hapticeffect;
    private GameObject visualsphere;
    private LoggerForBoth loggerforboth;
    bool isCalledOnce;

    void Start()
    {
        //movement = GameObject.Find("Movement");
        //hapticeffect = movement.GetComponent<HapticIntegration>();
        visualsphere = GameObject.Find("VisualSphere");
        loggerforboth = visualsphere.GetComponent<LoggerForBoth>();
        isCalledOnce = false;
    }

    void FixedUpdate()
    {
        if (ExperimentData.trialNumLeftBoth  ==0&& !isCalledOnce)
        {
            //Debug.Log("Send");
            isCalledOnce = true;
          File.WriteAllText(Application.dataPath + @"/Unity2Python.csv", loggerforboth.filename);
        }
    }

    //void WriteData(string data, string _filePath)
    //{
    //    string _path = _filePath;
    //    StreamWriter sw;
    //    FileInfo fi;
    //    fi = new FileInfo(_path);
    //    sw = fi.CreateText();
    //    sw.WriteLine(data);
    //    sw.Flush();
    //    sw.Close();
    //}
    //void SendFile(string content)
    //{
    //    using (sw = fi.AppendText())
    //    {
    //        sw.WriteLine(content);
    //        sw.Flush();
    //    }
    //}

}
