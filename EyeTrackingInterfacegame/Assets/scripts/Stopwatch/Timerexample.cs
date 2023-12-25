using UnityEngine;
using UnityEngine.UI;
using System.Net;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using UnityEngine.SceneManagement;

public class Timerexample : MonoBehaviour
{

    
    public Text disvar;
    float val;
    bool str;
    public static float startTime;
    public static float endTime;



    void Start()
    {
        val = 0;
        str = false;
        StartCoroutine(Auth());
    }

    void Update()
    {
        if (str)
        {
            val += Time.deltaTime;
        }

        disvar.text = val.ToString();

    }

    public void start()
    {
        str = true;
    }
    public void stop()
    {
        str = false;

    }
    public void reset()
    {
        str = false;
        val = 0;
    }
    public void exit()
    {
        StartCoroutine(play());
    }
    IEnumerator Auth()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/auth");
        www.SetRequestHeader("Authorization", Registration.sessionCookie);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.result);
            Debug.Log(www.downloadHandler.text);

        }
        www.Dispose();
    }
     IEnumerator play()
    {
        WWWForm form = new WWWForm();
        form.AddField("time", disvar.text);
        
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/stopwatch",form);
        www.SetRequestHeader("Authorization", Registration.sessionCookie);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) 
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.result);
            Debug.Log(www.downloadHandler.text);
            
        }
        www.Dispose();
    }
}
