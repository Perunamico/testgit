using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{

    private GameObject Object_ES_control;
    bool flag = false;
    HapticEffect hapticeffect;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Movement"); //Playerっていうオブジェクトを探す
        hapticeffect = obj.GetComponent<HapticEffect>();

        if (ExperimentData.trialNumLeft > 0 )//&& hapticeffect.effectflag)
        {
            //hapticeffect.effectflag = false;
            int idx = UnityEngine.Random.Range(0, ExperimentData.trialNumLeft);
            ExperimentData.currentAlpha = ExperimentData.posxList[idx];
            ExperimentData.trialNumLeft -= 1;
            ExperimentData.posxList.RemoveAt(idx);
        }
        Debug.Log((ExperimentData.trialNumAll - ExperimentData.trialNumLeft) + "/" + (ExperimentData.trialNumAll) + "  alpha=" + (ExperimentData.currentAlpha));
    }

    // Update is called once per frame
    void Update()
    {

        
        //void GotoNextScene()
        //{
        //   SceneManager.LoadScene(ExperimentData.EvaluationScene);
        //}
    }
}

