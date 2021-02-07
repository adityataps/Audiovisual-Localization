using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Valve.VR;

public class Speakers : MonoBehaviour



//Breaking down each list into subsets, and then plotting those points depending on threshold
//goals:
// allow someone to discern if there's vertical dispersion (responses are above a certain axis) -> 
//  compare between different offsets / congruent and incongruent
//  toggle
//  tone coming from each blue spheres; pitch of tone determined by respose time <- turning blue sphere on
// look at differences in response times via sound
//  spotlight on controller; average of response times of all the points
//  filtering w/ congruent or incongruent
// some way of toggling FOUR DIFFERENT CONDITIONS
//  



// script on each ball per fixedupdate ? 
// 



{

    List<String> incongruent = new List<string>();
    List<String> congruent = new List<string>();
    List<List<GameObject>> ballPairs = new List<List<GameObject>>();
    //public SteamVR_Action_Boolean triggerpull;
    //public SteamVR_Input_Sources VRinputSource;

    //public void pullTrigger()
    //{
    //    triggerpull.AddOnStateDownListener(DoTriggerStuff, VRinputSource);
    //}

    //public void DoTriggerStuff(SteamVR_Action_Boolean thisStuff, SteamVR_Input_Sources sources)
    //{
    //    Debug.Log("trigger is pulled");
    //}

    //private void OnEnable()
    //{
    //    pullTrigger();
    //}



    // Start is called before the first frame update
    void Start()
    {

        //triggerpull.AddOnStateDownListener(DoTriggerStuff, VRinputSource);

        string[] filesInFolder = Directory.GetFiles(@"C:\Users\atapshalkar3\Documents\Unity\unitydata1", "*.csv", SearchOption.TopDirectoryOnly);
        if (filesInFolder.Length == 0)
        {
            throw new System.IO.FileLoadException("Couldn't find any files in the folder. Please make sure you're using the right folder.");
        }

        foreach (string file in filesInFolder)
        {
            analyzeFile(file);
        }

        generateBalls();

    }

    void analyzeFile(string filepath)
    {
        using (var reader = new StreamReader(filepath))
        {
            reader.ReadLine();
            String line = null;

            do
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    return;
                }

                analyzeString(line);


            } while (true);



        }
    }

    void analyzeString(string lineRead)
    {

        string[] values = lineRead.Split(',');
        if (values[1].Equals("temporal"))
        {
            return;
        }

        //if (values[4].Equals("ao-incongruent"))
        //{
        //    incongruent.Add(lineRead);
        //}

        //if (values[4].Equals("ao-congruent"))
        //{
        //    congruent.Add(lineRead);
        //}

        if (values[26].Equals("early_training"))
        {
            congruent.Add(lineRead);
            Console.WriteLine("hey");
        }

    }

    void generateBalls()
    {
        foreach (string incong in incongruent)
        {

            string[] values = incong.Split(',');
            Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = response;
            sphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            sphere.AddComponent<ballProperties>();
            sphere.GetComponent<ballProperties>().setCongruencyCondition("Incongruent");
            sphere.GetComponent<ballProperties>().setBallType("Response");
            sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
            sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));


            Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
            GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere2.transform.position = actual;
            sphere2.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            sphere2.AddComponent<ballProperties>();
            sphere2.GetComponent<ballProperties>().setCongruencyCondition("Incongruent");
            sphere2.GetComponent<ballProperties>().setBallType("Actual");
            sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
            sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));


            Vector3 difference = response - actual;
            GameObject lineBetween = new GameObject();
            lineBetween.transform.position = response;
            lineBetween.AddComponent<LineRenderer>();
            LineRenderer lineRender = lineBetween.GetComponent<LineRenderer>();

            lineRender.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
            lineRender.startColor = Color.red;
            lineRender.endColor = Color.blue;

            lineRender.SetPosition(0, response);
            lineRender.SetPosition(1, actual);
            lineRender.SetWidth(0.005f, 0.01f);

            List<GameObject> balls = new List<GameObject>();
            balls.Add(sphere);
            balls.Add(sphere2);
            ballPairs.Add(balls);

        }

        foreach (string cong in congruent)
        {

            string[] values = cong.Split(',');
            Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = response;
            sphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            sphere.AddComponent<ballProperties>();
            sphere.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
            sphere.GetComponent<ballProperties>().setBallType("Response");
            sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
            sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

            Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
            GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere2.transform.position = actual;
            sphere2.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            sphere2.AddComponent<ballProperties>();
            sphere2.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
            sphere2.GetComponent<ballProperties>().setBallType("Actual");
            sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
            sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

            Vector3 difference = response - actual;
            GameObject lineBetween = new GameObject();
            lineBetween.transform.position = response;
            lineBetween.AddComponent<LineRenderer>();
            LineRenderer lineRender = lineBetween.GetComponent<LineRenderer>();

            lineRender.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
            lineRender.startColor = Color.gray;
            lineRender.endColor = Color.blue;

            lineRender.SetPosition(0, response);
            lineRender.SetPosition(1, actual);
            lineRender.SetWidth(0.005f, 0.01f);

            List<GameObject> balls = new List<GameObject>();
            balls.Add(sphere);
            balls.Add(sphere2);
            ballPairs.Add(balls);

        }
    }


    // Update is called once per frame
    void Update()
    {

        //generateBalls();

    }

    private void FixedUpdate()
    {
        //generateBalls();
    }
}
