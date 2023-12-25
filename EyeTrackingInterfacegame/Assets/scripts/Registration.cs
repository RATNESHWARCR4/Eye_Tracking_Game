using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public static string sessionCookie;
    public string sessionId = "Bearer";
    public Button submitButton;

    public void CallRegister()
    {
       
        StartCoroutine(Register());
    }

    public void CallLogin()
    {

        StartCoroutine(Login());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.result);
            SceneManager.LoadScene(2);
        }
        www.Dispose();
    }
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/login", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            //Debug.LogError($"Error {www.responseCode} - {www.error}");
            Debug.Log(www.downloadHandler.text);

        }
        else
        {
            Debug.Log(www.result);
            Debug.Log(www.downloadHandler.text);
            string s = www.GetResponseHeader("Authorization");
            sessionCookie = s.Split(sessionId)[1];
            if(sessionCookie!=null)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                Debug.Log("Log in Failed");
            }
        }
        www.Dispose();
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
