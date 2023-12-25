using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.Text;
using UnityEngine.Networking;

public class ForgetPass : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public InputField passwordField2;

    public Button submitButton;

    public void CallChangePassword()
    {
        if(passwordField.text == passwordField2.text)
        {
            Debug.Log("Changing password");
            StartCoroutine(ChangePassword());
            
        }
        else
        {
            Debug.Log("Both Password Field don't match each other");
        }
        
    }
    IEnumerator ChangePassword()
    {
            WWWForm form = new WWWForm();
            form.AddField("username", nameField.text);
            form.AddField("password", passwordField.text);

            UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/ChangePassword", form);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
            www.Dispose();
    }
    public void VerifyResetInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8 && passwordField2.text.Length >= 8);
    }

} 


    
    

