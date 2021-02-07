using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ControllerDpad : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean up;
    public SteamVR_Action_Boolean down;
    public SteamVR_Action_Boolean left;
    public SteamVR_Action_Boolean right;

    ReadCSV_and_Generate generateBalls = new ReadCSV_and_Generate();

    // a reference to the hand
    public SteamVR_Input_Sources handType;
    //reference to the sphere
    //public GameObject Sphere;
    void Start()
    {
        
        up.AddOnStateDownListener(UpClick, handType);
        down.AddOnStateDownListener(DownClick, handType);
        left.AddOnStateDownListener(LeftClick, handType);
        right.AddOnStateDownListener(RightClick, handType);
    }

    //public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    //{
    //    Debug.Log("clicked");
    //    //Sphere.GetComponent<MeshRenderer>().enabled = true;
    //}

    //public void DestroyAllGameObjects()
    //{
        
    //    foreach (GameObject toDestroy in ReadCSV_and_Generate.allBalls)
    //    {
    //        Destroy(toDestroy);
    //    }
    //}

    public void UpClick(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        generateBalls.upPressed = true;
        //Debug.Log("up clicked");
        ReadCSV_and_Generate.aioi = !(ReadCSV_and_Generate.aioi);
        if (ReadCSV_and_Generate.aioi)
        {
            foreach (GameObject ball in ReadCSV_and_Generate.aioiList)
            {
                ball.GetComponent<Renderer>().enabled = true;
            }
            Debug.Log("Act Incong, Obj Incong - Enabled");
        } else
        {
            foreach (GameObject ball in ReadCSV_and_Generate.aioiList)
            {
                ball.GetComponent<Renderer>().enabled = false;
            }
            Debug.Log("Act Incong, Obj Incong - Disabled");
        }
        //DestroyAllGameObjects();
        //System.Threading.Thread.Sleep(500);
        //generateBalls.upPressed = false;
    }

    public void DownClick(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        generateBalls.downPressed = true;
        //Debug.Log("down clicked");
        ReadCSV_and_Generate.acoc = !(ReadCSV_and_Generate.acoc);
        if (ReadCSV_and_Generate.acoc)
        {
            foreach (GameObject ball in ReadCSV_and_Generate.acocList)
            {
                ball.GetComponent<Renderer>().enabled = true;
            }
            Debug.Log("Act Cong, Obj Cong - Enabled");
        }
        else
        {
            foreach (GameObject ball in ReadCSV_and_Generate.acocList)
            {
                ball.GetComponent<Renderer>().enabled = false;
            }
            Debug.Log("Act Cong, Obj Cong - Disabled");
        }
        //DestroyAllGameObjects();
        //System.Threading.Thread.Sleep(500);
        //generateBalls.downPressed = false;
    }

    public void LeftClick(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        generateBalls.leftPressed = true;
        //Debug.Log("left clicked");
        ReadCSV_and_Generate.aioc = !(ReadCSV_and_Generate.aioc);
        if (ReadCSV_and_Generate.aioc)
        {
            foreach (GameObject ball in ReadCSV_and_Generate.aiocList)
            {
                ball.GetComponent<Renderer>().enabled = true;
            }
            Debug.Log("Act Incong, Obj Cong - Enabled");
        }
        else
        {
            foreach (GameObject ball in ReadCSV_and_Generate.aiocList)
            {
                ball.GetComponent<Renderer>().enabled = false;
            }
            Debug.Log("Act Incong, Obj Cong - Disabled");
        }
        //DestroyAllGameObjects();
        //System.Threading.Thread.Sleep(500);
        //generateBalls.leftPressed = false;
    }

    public void RightClick(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        generateBalls.rightPressed = true;
        //Debug.Log("right clicked");
        ReadCSV_and_Generate.acoi = !(ReadCSV_and_Generate.acoi);
        if (ReadCSV_and_Generate.acoi)
        {
            foreach (GameObject ball in ReadCSV_and_Generate.acoiList)
            {
                ball.GetComponent<Renderer>().enabled = true;
            }
            Debug.Log("Act Cong, Obj Incong - Enabled");
        }
        else
        {
            foreach (GameObject ball in ReadCSV_and_Generate.acoiList)
            {
                ball.GetComponent<Renderer>().enabled = false;
            }
            Debug.Log("Act Cong, Obj Incong - Disabled");
        }
        //DestroyAllGameObjects();
        //System.Threading.Thread.Sleep(500);
        //generateBalls.rightPressed = false;
    }

    void Update()
    {

    }
}