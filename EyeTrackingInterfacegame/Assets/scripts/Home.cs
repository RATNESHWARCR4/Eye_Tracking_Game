using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void gotoregister()
    {
        SceneManager.LoadScene(1);

    }
    public void gotologin()
    {
        SceneManager.LoadScene(2);

    }

    public void gotohome()
    {
        SceneManager.LoadScene(0);
    }

    public void gotostopwatch()
    {
        SceneManager.LoadScene(3);
    }
    public void gotostar()
    {
        SceneManager.LoadScene(4);
    }
    public void gotomainmenu()
    {
        SceneManager.LoadScene(5);
    }
    public void gotoForgetPassword()
    {
        SceneManager.LoadScene(6);
    }
    public void logout()
    {
        SceneManager.LoadScene(0);
    }
}
