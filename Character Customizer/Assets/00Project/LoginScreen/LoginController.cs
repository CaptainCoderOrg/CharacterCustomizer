using UnityEngine;
using CaptainCoder;
using System;

public class LoginController : MonoBehaviour
{
    public UnityEngine.UI.Text Output;
    private LoginService service; // = LoginService.GetService();

    public void Start()
    {
        service = LoginService.GetService(this);
    }
    public void OnConnect()
    {
        service.Authenticate();
    }
    public void OnLogout()
    {
        service.Logout();
    }

    public void DisplayInfo(string info)
    {
        Debug(info);
    }

    public void DisplayErrorObject(string error)
    {
        Debug(error);
    }

    public void OnSignedIn(string data)
    {
        this.service.OnSignedIn(data);      
    }

    public void OnSignedOut(string data)
    {
        this.service.OnSignedOut(data);       
    }

    internal void Debug(string data)
    {
        Output.text += $"{data}\n";
        UnityEngine.Debug.Log(data);
    }
}