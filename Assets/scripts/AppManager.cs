using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class AppManager : MonoBehaviour
{
    [Header("Boolean")]
    public bool running = false;
    public bool isActive = true;

    [Header("Values")]
    public float xTime = 60f;

    [Header("Object")]
    public WindowsToastNotification toast;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (running == false)
            {
                //start the loop
                StartCoroutine(StartLoop());
            }
        }
        else
        {
            //stop the loop
            StopAllCoroutines();
            running = false;
        }
    }

    //aplied toggle value to isActive bool
    public void OnToggleChange(bool tickOn)
    {
        isActive = tickOn;
    }

    public void DropDownSample(int index)
    {
        switch (index)
        {
            //1min
            case 0: xTime = 60f; break;
            //10min
            case 1: xTime = 600f; break;
            //20 min *
            case 2: xTime = 1200f; break;
            //30 min
            case 3: xTime = 1800f; break;
            //40 min
            case 4: xTime = 2400f; break;
            //1 h
            case 5: xTime = 3600f; break;
            //1 h 30 min
            case 6: xTime = 5400f; break;
            //2 h
            case 7: xTime = 7200f; break;
        }
    }
    //send toast every x second
    public IEnumerator StartLoop()
    {
        Debug.Log("Start/restart");
        Debug.Log(xTime.ToString());
        running = true;
        yield return new WaitForSeconds(xTime);
        toast.SendNotification();
        StartCoroutine(StartLoop());
    }
}
