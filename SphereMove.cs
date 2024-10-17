using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Text;

public class SphereMove : MonoBehaviour
{
    // Start is called before the first frame update
    //Vector3 current = Vector3.zero;
    Vector3 target;
    Vector3 homepos;
    Vector3 currentpos;
    bool startflag = false;
    float step;
    public bool isProcessing = false;
    bool ismoved = false;
    private StreamWriter sw;
    private FileInfo fi;

    private Vector3 LocalStylusPos;
    [System.NonSerialized] public bool isLogged = true;
    GameObject movement;
    public string participantname;

    private DateTime date;
    string str;
    string filename;
    string format;

    GameObject obj;
    SphereOffsetForVisual sphereoffsetforvisual;
    //GameObject logger;
    //LoggerVisual dataloggerqiita;



    void Start()
    {
        obj = GameObject.Find("Grabber");
        sphereoffsetforvisual = obj.GetComponent<SphereOffsetForVisual>();
        isLogged = true;
        date = DateTime.Now;
        string format = "yyyy-MM-dd-HH-mm-ss";
        string filename = "/Data/" + participantname + "_Visual_" + date.ToString(format) + ".csv";
        //string filename = "/Data/" + ExperimentData.fileName + date.ToString(format) + ".csv";
        fi = new FileInfo(Application.dataPath + filename);

        


        }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);
        while (Vector3.Distance(this.transform.position, target) > 5f)
        {
            transform.Translate(4f, 0f, 0f);
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        while (Vector3.Distance(this.transform.position, homepos) > 5f)
        {
            transform.Translate(-4f, 0f, 0f);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Select());
    }
    IEnumerator Select()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                transform.Translate(-2f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(2f, 0f, 0f);
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Vector3 truestimuli = target - homepos;
        Vector3 ans = transform.position - homepos;
        str = "True Stimuli is" + truestimuli.x + "Answer is" + ans.x;
        sw = fi.AppendText();
        sw.WriteLine(str);
        sw.Flush();
        sw.Close();
        transform.position = homepos;
        isLogged = true;
        yield return null;
    }


        // Update is called once per frame
        void Update()
        {
            Debug.Log(startflag);

            if (!startflag && Input.GetKeyDown(KeyCode.S))

            {
                homepos = sphereoffsetforvisual.offsetvisual;
                Debug.Log(homepos);
                Debug.Log(startflag); 
                this.transform.position = homepos;
                GameObject stylus = GameObject.Find("Sphere");
                stylus.SetActive(false);
                GameObject movement = GameObject.Find("Movement");
                movement.SetActive(false);

            }
            if (!startflag && Input.GetKeyDown(KeyCode.Return))

            {
                startflag = true;
                Debug.Log("start");
            }


            //step = 2.0f * Time.deltaTime;
            if (startflag && isLogged)
            {
                isLogged = false;
                //Debug.Log("Move");
                if (ExperimentData.trialNumLeft > 0)//&& hapticeffect.effectflag)
                {
                    //hapticeffect.effectflag = false;
                    int idx = UnityEngine.Random.Range(0, ExperimentData.trialNumLeft);
                    ExperimentData.currentAlpha = ExperimentData.visualdistList[idx];
                    ExperimentData.trialNumLeft -= 1;
                    ExperimentData.visualdistList.RemoveAt(idx);
                    Debug.Log(ExperimentData.currentAlpha);
                    Debug.Log((ExperimentData.trialNumAll - ExperimentData.trialNumLeft) + "/" + (ExperimentData.trialNumAll) + "  alpha=" + (ExperimentData.currentAlpha));

                }
                target = homepos + new Vector3(ExperimentData.currentAlpha, 0, 0);

                StartCoroutine("Move");
                //if(ismoved){
                //    if (Input.GetKey(KeyCode.D))
                //    {
                //        Debug.Log("Down");
                //        transform.position += -1 * Time.deltaTime * new Vector3(1,0,0);
                //    }
                //    else if (Input.GetKey(KeyCode.E))
                //    {
                //        transform.position += 1 * Time.deltaTime * new Vector3(1, 0, 0);
                //    }
                //    StartCoroutine("Select");
                //}


                //transform.position = Vector3.MoveTowards(transform.position, target, step);
                //Posx = ExperimentData.currentAlpha;

            }
        }
    }
    
            
        

