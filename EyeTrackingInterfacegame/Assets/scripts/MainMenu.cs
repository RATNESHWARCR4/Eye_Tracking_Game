using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Net;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string data;
    public static string sessionCookie;
    public string sessionId = "Bearer";
    public TMP_Text canvas_text;
    public Button logoutButton;
    public Button analysisButton;

    void Start()
    {
        
        StartCoroutine(GetData());
        logoutButton.onClick.AddListener(CallLogout);
        analysisButton.onClick.AddListener(CallAnalysis);

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/data");
        Debug.Log(Registration.sessionCookie);
        www.SetRequestHeader("Authorization", Registration.sessionCookie);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);

        }
        else
        { 
            data = www.downloadHandler.text;
           
            canvas_text.text = "Welcome , " + data;
            
        }
        www.Dispose();
    }    

    public void CallLogout()
    {

        StartCoroutine(LogoutRequest());
    }

    IEnumerator LogoutRequest()
    {
        // Replace "http://localhost:3000" with the URL of your Node.js server
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/logout"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Logged out successfully!");
                Registration.sessionCookie = null;
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Logout failed: " + www.error);
            }
            www.Dispose();
        }
        
    }

    public void CallAnalysis()
    {

        UnityEngine.Application.OpenURL("http://localhost:3000/user/"+Registration.sessionCookie);
    }
   

}
