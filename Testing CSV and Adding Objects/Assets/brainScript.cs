using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class brainScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        /*
        Vector3 newBall = new Vector3(3, 2, 1);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = newBall;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        */

        string filepath = "./TestCSV/MSIVR_fulldata_participant_22.csv";
        callBalls(filepath);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Take in a document and instantiate spheres for coordinates
    void callBalls(string filepath)
    {

        using (var reader = new StreamReader(filepath))
        {

            reader.ReadLine();

            for (int i = 105; i < 352; i++)
            {

                var line = reader.ReadLine();
                var values = line.Split(',');

                Vector3 response = new Vector3(float.Parse(values[21]), float.Parse(values[22]), float.Parse(values[23]));
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = response;
                sphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

                Vector3 actual = new Vector3(float.Parse(values[18]), float.Parse(values[19]), float.Parse(values[20]));
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere2.transform.position = actual;
                sphere2.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                sphere2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

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






                // TODO
                // draw lines between response and audio location
                // look into line renderer
                // iterating through multiple data files
                // look into generating pitched audio
                // https://docs.unity3d.com/ScriptReference/AudioSource-pitch.html

                // change 3D models to something that means audio
                // have different colors for different exp conditions (ao_congruent/incongruent)
                // make sure all trials are spatial by checking string
                // averaging as parameter for brain
     




            }

        }

    }
}
