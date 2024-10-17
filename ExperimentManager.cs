using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ExperimentManager : MonoBehaviour
{
    //experiment settings
    public string fileName;
    public string axis; //yet to be used
    public bool isPractice;
    public bool isChomoro;
    public bool isChomopractice;
    //private string ExperimentScene;

    // Start is called before the first frame update
    void Start()
    {
        ExperimentData.fileName = fileName;
        ExperimentData.axis = axis;

        System.DateTime centuryBegin = new System.DateTime(2001, 1, 1);
        ExperimentData.timeStamp = System.DateTime.Now.Ticks - centuryBegin.Ticks;

        //ExperimentData.alphaList = new List<float> {-14,-12,-10,-8,-6,-4,-2,0,2,4,6,8,10,12,14, -14,-12,-10,-8,-6,-4,-2,0,2,4,6,8,10,12,14};
        //ExperimentData.trialNumLeft = 30; //length

        

        if (isPractice)
        {
            ExperimentData.posxList = new List<float> { -15, 15 };
            ExperimentData.visualdistList = new List<float> {200,250 };
            ExperimentData.trialNumLeft = 2; //length
            ExperimentData.trialNumAll = 2;
            ExperimentData.posxListBoth = new List<float> {
           70,100,130,160,190,
            };

            ExperimentData.gainList230 = new List<float> {
           1f
           
        };
            ExperimentData.gainList260 = new List<float> {
           0.885f
        };
            ExperimentData.gainList290 = new List<float> {
          1.20f
         
        };
            ExperimentData.gainList320 = new List<float> {
          0.90f
         
        };
            ExperimentData.gainList350 = new List<float> {
           0.657f,
        };
            ExperimentData.trialNumLeft230 = 1;
            ExperimentData.trialNumLeft260 = 1;
            ExperimentData.trialNumLeft290 = 1;
            ExperimentData.trialNumLeft320 = 1;
            ExperimentData.trialNumLeft350 = 1;
            ExperimentData.trialNumLeftBoth = 5; //length
            ExperimentData.trialNumAllBoth = 5;
        }
        else if (isChomoro) {

            ExperimentData.posxList = new List<float> { -15, 15 };
            ExperimentData.visualdistList = new List<float> { 200, 250 };
            ExperimentData.trialNumLeft = 2; //length
            ExperimentData.trialNumAll = 2;
            ExperimentData.posxListBoth = new List<float> {
           140,140,140,140,140,140
            };

            ExperimentData.gainList230 = new List<float> {
           

        };
            ExperimentData.gainList300 = new List<float> {
                1f,1.2f,0.8f,1f,1.2f,0.8f
           //1.6f,1.6f,1.6f,1.6f,1.6f,1.6f

        };
            ExperimentData.gainList260 = new List<float> {
    
        };
            ExperimentData.gainList290 = new List<float> {
   

        };
            ExperimentData.gainList320 = new List<float> {
     

        };
            ExperimentData.gainList350 = new List<float> {
       
        };
            ExperimentData.trialNumLeft230 = 0;
            ExperimentData.trialNumLeft260 = 0;
            ExperimentData.trialNumLeft290 = 0;
            ExperimentData.trialNumLeft300 = 6;
            ExperimentData.trialNumLeft320 = 0;
            ExperimentData.trialNumLeft350 = 0;
            ExperimentData.trialNumLeftBoth = 6;
            ExperimentData.trialNumAllBoth = 6;

        }
        else if (isChomopractice)
        {

            ExperimentData.posxList = new List<float> { -15, 15 };
            ExperimentData.visualdistList = new List<float> { 200, 250 };
            ExperimentData.trialNumLeft = 2; //length
            ExperimentData.trialNumAll = 2;
            ExperimentData.posxListBoth = new List<float> {
           140
            };

            ExperimentData.gainList230 = new List<float>
            {


            };
            ExperimentData.gainList300 = new List<float> {
           1f

        };
            ExperimentData.gainList260 = new List<float>
            {

            };
            ExperimentData.gainList290 = new List<float>
            {


            };
            ExperimentData.gainList320 = new List<float>
            {


            };
            ExperimentData.gainList350 = new List<float>
            {

            };
            ExperimentData.trialNumLeft230 = 0;
            ExperimentData.trialNumLeft260 = 0;
            ExperimentData.trialNumLeft290 = 0;
            ExperimentData.trialNumLeft300 = 1;
            ExperimentData.trialNumLeft320 = 0;
            ExperimentData.trialNumLeft350 = 0;
            ExperimentData.trialNumLeftBoth = 1;
            ExperimentData.trialNumAllBoth = 1;

        }
        else
        {
            ExperimentData.posxList = new List<float> {
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
            };
           ExperimentData.visualdistList = new List<float> {
           230,260,290,320,350,
           230,260,290,320,350,
          230,260,290,320,350,
           230,260,290,320,350
           };
            ExperimentData.posxListBoth = new List<float> {
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
           70,100,130,160,190,
            };

            ExperimentData.gainList230 = new List<float> {
           1f,1.13f,1.26f,1.39f,1.52f,
           1f,1.13f,1.26f,1.39f,1.52f,
           1f,1.13f,1.26f,1.39f,1.52f,
           1f,1.13f,1.26f,1.39f,1.52f
        };
            ExperimentData.gainList260 = new List<float> {
           0.885f,1f,1.115f,1.23f,1.346f,
           0.885f,1f,1.115f,1.23f,1.346f,
           0.885f,1f,1.115f,1.23f,1.346f,
           0.885f,1f,1.115f,1.23f,1.346f
        };
            ExperimentData.gainList290 = new List<float> {
           0.793f,0.8965f,1f,1.1f,1.20f,
           0.793f,0.8965f,1f,1.1f,1.20f,
           0.793f,0.8965f,1f,1.1f,1.20f,
           0.793f,0.8965f,1f,1.1f,1.20f
        };
            ExperimentData.gainList320 = new List<float> {
           0.718f,0.8125f,0.90f,1f,1.09f,
           0.718f,0.8125f,0.90f,1f,1.09f,
           0.718f,0.8125f,0.90f,1f,1.09f,
           0.718f,0.8125f,0.90f,1f,1.09f
        };
            ExperimentData.gainList350 = new List<float> {
           0.657f,0.743f,0.829f,0.914f,1f,
           0.657f,0.743f,0.829f,0.914f,1f,
           0.657f,0.743f,0.829f,0.914f,1f,
           0.657f,0.743f,0.829f,0.914f,1f
        };
            ExperimentData.trialNumLeft230 = 20;
            ExperimentData.trialNumLeft260 = 20;
            ExperimentData.trialNumLeft290 = 20;
            ExperimentData.trialNumLeft320 = 20;
            ExperimentData.trialNumLeft350 = 20;
            ExperimentData.trialNumLeft = 20; //length
            ExperimentData.trialNumAll = 20;
            ExperimentData.trialNumLeftBoth = 100; //length
            ExperimentData.trialNumAllBoth = 100;
        };

            
            
            //ExperimentData.posxList = new List<float> {
            //    0,0,0
            //};
            
        



        //record setting
        if (!Directory.Exists(Application.dataPath + "/Data/" + ExperimentData.fileName))
        {
            Directory.CreateDirectory(Application.dataPath + "/Data/" + ExperimentData.fileName);
        }

        if (!Directory.Exists(Application.dataPath + "/Data/" + ExperimentData.fileName + "/motion"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Data/" + ExperimentData.fileName + "/motion");
        }

    }

    private void Update()
    { 
        
    }

}

public static class ExperimentData
{
    public static string fileName;
    public static string axis;


    public static List<float> posxList;
    public static List<float> posxListBoth;
    public static List<float> visualdistList;
    public static List<float> gainList230;
    public static List<float> gainList260;
    public static List<float> gainList290;
    public static List<float> gainList300;
    public static List<float> gainList320;
    public static List<float> gainList350;
    public static int trialNumLeft;
    public static int trialNumLeft230;
    public static int trialNumLeft260;
    public static int trialNumLeft290;
    public static int trialNumLeft300;
    public static int trialNumLeft320;
    public static int trialNumLeft350;
    public static int trialNumLeftBoth;
    public static int trialNumAll;
    public static int trialNumAllBoth;

    public static float currentAlpha;
    public static float currentGain;

    public static long timeStamp;
}
