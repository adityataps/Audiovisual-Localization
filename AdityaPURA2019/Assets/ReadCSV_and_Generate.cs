using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Valve.VR;
//[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ReadCSV_and_Generate : MonoBehaviour



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



    List<string> act_incong_obj_incong = new List<string>();
    static public bool aioi = false;
    public bool upPressed = false;
    public static Renderer aioiRenderer;
    public static Renderer aioiRenderer2;
    //public static Renderer aioiLines;
    List<string> act_cong_obj_cong = new List<string>();
    static public bool acoc = false;
    public bool downPressed = false;
    public static Renderer acocRenderer;
    public static Renderer acocRenderer2;
    //public static Renderer acocLines;
    List<string> act_incong_obj_cong = new List<string>();
    static public bool aioc = true;
    public bool leftPressed = false;
    public static Renderer aiocRenderer;
    public static Renderer aiocRenderer2;
    //public static Renderer aiocLines;
    List<string> act_cong_obj_incong = new List<string>();
    static public bool acoi = true;
    public bool rightPressed = false;
    public static Renderer acoiRenderer;
    public static Renderer acoiRenderer2;
    //public static Renderer acoiLines;

    List<List<GameObject>> ballPairs = new List<List<GameObject>>();
    public static List<GameObject> allBalls = new List<GameObject>();

    public static List<GameObject> acocList = new List<GameObject>();
    public static List<GameObject> aioiList = new List<GameObject>();
    public static List<GameObject> acoiList = new List<GameObject>();
    public static List<GameObject> aiocList = new List<GameObject>();
    public static List<LineRenderer> acocLinesRender = new List<LineRenderer>();
    public static List<LineRenderer> aioiLinesRender = new List<LineRenderer>();
    public static List<LineRenderer> acoiLinesRender = new List<LineRenderer>();
    public static List<LineRenderer> aiocLinesRender = new List<LineRenderer>();

    public Material objMaterial;


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
        if (values[26].Equals("experiment_trial"))
        {
            if (values[1].Equals("temporal"))
            {
                return;
            }

            if (values[4].Equals("act_cong_obj_cong"))
            {
                act_cong_obj_cong.Add(lineRead);
            }

            if (values[4].Equals("act_incong_obj_incong"))
            {
                act_incong_obj_incong.Add(lineRead);
            }

            if (values[4].Equals("act_cong_obj_incong"))
            {
                act_cong_obj_incong.Add(lineRead);
            }

            if (values[4].Equals("act_incong_obj_cong"))
            {
                act_incong_obj_cong.Add(lineRead);
            }

        }

    }

    void generateBalls()
    {

        //Debug.Log(aioi);
        //Debug.Log(acoi);
        //Debug.Log(aioc);
        //Debug.Log(acoc);

        //if (aioi == true)
        //{
        foreach (string incong in act_incong_obj_incong)
        {
            float rand = UnityEngine.Random.Range(1, 10);
            
            if (rand >= 8)
            {

                string[] values = incong.Split(',');
                Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere.transform.position = response;
                sphere.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                aioiRenderer = sphere.GetComponent<Renderer>();
                aioiRenderer.material = objMaterial;
                aioiRenderer.material.SetColor("_Color", Color.red);
                sphere.AddComponent<ballProperties>();
                sphere.GetComponent<ballProperties>().setCongruencyCondition("Incongruent");
                sphere.GetComponent<ballProperties>().setBallType("Response");
                sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));


                Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere2.transform.position = actual;
                sphere2.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                aioiRenderer2 = sphere2.GetComponent<Renderer>();
                aioiRenderer2.material.SetColor("_Color", Color.blue);
                sphere2.AddComponent<ballProperties>();
                sphere2.GetComponent<ballProperties>().setCongruencyCondition("Incongruent");
                sphere2.GetComponent<ballProperties>().setBallType("Actual");
                sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                aioiList.Add(sphere);
                aioiList.Add(sphere2);

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
                lineRender.SetWidth(0.001f, 0.001f);

                aioiList.Add(lineBetween);

                List<GameObject> balls = new List<GameObject>();
                balls.Add(sphere);
                balls.Add(sphere2);
                ballPairs.Add(balls);

            }
        }
        //}

        //if (acoc == true)
        //{
        foreach (string cong in act_cong_obj_cong)
        {
            float rand = UnityEngine.Random.Range(1, 10);

            if (rand >= 8)
            {

                string[] values = cong.Split(',');
                Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere.transform.position = response;
                sphere.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                acocRenderer = sphere.GetComponent<Renderer>();
                acocRenderer.material = objMaterial;
                acocRenderer.material.SetColor("_Color", Color.green);
                sphere.AddComponent<ballProperties>();
                sphere.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere.GetComponent<ballProperties>().setBallType("Response");
                sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere2.transform.position = actual;
                sphere2.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                acocRenderer2 = sphere2.GetComponent<Renderer>();
                acocRenderer2.material.SetColor("_Color", Color.blue);
                sphere2.AddComponent<ballProperties>();
                sphere2.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere2.GetComponent<ballProperties>().setBallType("Actual");
                sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                acocList.Add(sphere);
                acocList.Add(sphere2);

                Vector3 difference = response - actual;
                GameObject lineBetween = new GameObject();
                lineBetween.transform.position = response;
                lineBetween.AddComponent<LineRenderer>();
                LineRenderer lineRender = lineBetween.GetComponent<LineRenderer>();
                lineRender.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
                lineRender.startColor = Color.green;
                lineRender.endColor = Color.blue;
                lineRender.SetPosition(0, response);
                lineRender.SetPosition(1, actual);
                lineRender.SetWidth(0.001f, 0.001f);

                acocList.Add(lineBetween);

                List<GameObject> balls = new List<GameObject>();
                balls.Add(sphere);
                balls.Add(sphere2);
                ballPairs.Add(balls);

            }
        }
        //}

        //if (acoi == true)
        //{
        foreach (string congIncong in act_cong_obj_incong)
        {

            float rand = UnityEngine.Random.Range(1, 10);

            if (rand >= 8)
            {

                string[] values = congIncong.Split(',');
                Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere.transform.position = response;
                sphere.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                acoiRenderer = sphere.GetComponent<Renderer>();
                acoiRenderer.material = objMaterial;
                acoiRenderer.material.SetColor("_Color", Color.yellow);
                sphere.AddComponent<ballProperties>();
                sphere.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere.GetComponent<ballProperties>().setBallType("Response");
                sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere2.transform.position = actual;
                sphere2.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                acoiRenderer2 = sphere2.GetComponent<Renderer>();
                acoiRenderer2.material.SetColor("_Color", Color.blue);
                sphere2.AddComponent<ballProperties>();
                sphere2.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere2.GetComponent<ballProperties>().setBallType("Actual");
                sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                acoiList.Add(sphere);
                acoiList.Add(sphere2);

                Vector3 difference = response - actual;
                GameObject lineBetween = new GameObject();
                lineBetween.transform.position = response;
                lineBetween.AddComponent<LineRenderer>();
                LineRenderer lineRender = lineBetween.GetComponent<LineRenderer>();
                lineRender.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
                lineRender.startColor = Color.yellow;
                lineRender.endColor = Color.blue;
                lineRender.SetPosition(0, response);
                lineRender.SetPosition(1, actual);
                lineRender.SetWidth(0.001f, 0.001f);

                acoiList.Add(lineBetween);

                List<GameObject> balls = new List<GameObject>();
                balls.Add(sphere);
                balls.Add(sphere2);
                ballPairs.Add(balls);

            }
        }
        //}

        //if (aioc == true)
        //{
        foreach (string incongCong in act_incong_obj_cong)
        {

            float rand = UnityEngine.Random.Range(1, 10);

            if (rand >= 8)
            {

                string[] values = incongCong.Split(',');
                Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere.transform.position = response;
                sphere.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                aiocRenderer = sphere.GetComponent<Renderer>();
                aiocRenderer.material = objMaterial;
                aiocRenderer.material.SetColor("_Color", Color.gray);
                sphere.AddComponent<ballProperties>();
                sphere.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere.GetComponent<ballProperties>().setBallType("Response");
                sphere.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sphere2.transform.position = actual;
                sphere2.transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
                aiocRenderer2 = sphere2.GetComponent<Renderer>();
                aiocRenderer2.material.SetColor("_Color", Color.blue);
                sphere2.AddComponent<ballProperties>();
                sphere2.GetComponent<ballProperties>().setCongruencyCondition("Congruent");
                sphere2.GetComponent<ballProperties>().setBallType("Actual");
                sphere2.GetComponent<ballProperties>().setResponseTime(double.Parse(values[10]));
                sphere2.GetComponent<ballProperties>().setAngleOffset(double.Parse(values[5]));

                aiocList.Add(sphere);
                aiocList.Add(sphere2);

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
                lineRender.SetWidth(0.001f, 0.001f);

                aiocList.Add(lineBetween);

                List<GameObject> balls = new List<GameObject>();
                balls.Add(sphere);
                balls.Add(sphere2);
                ballPairs.Add(balls);

            }

        }
        //}
    }


    // Update is called once per frame
    void Update()
    {

        //generateBalls();
        //SomeRoutine();

    }

    //IEnumerator SomeRoutine()
    //{

    //    //do stuff

    //    //wait for space to be pressed
    //    while (!upPressed && !downPressed && !leftPressed && !rightPressed)
    //    {
    //        yield return null;
    //    }

    //    //do stuff once space is pressed

    //}


}
