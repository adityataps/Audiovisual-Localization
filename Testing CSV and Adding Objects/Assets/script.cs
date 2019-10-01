using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        print("hello world");
        print(Directory.GetCurrentDirectory());

        string filepath = "./TestCSV/testCSV.csv";

        using (var reader = new StreamReader(filepath))
        {

            var line = reader.ReadLine();
            var line2 = reader.ReadLine();
            var values = line2.Split(',');

            // Particle(x, y, z, color)

            print(values[0]);
            print(values[1]);
            print(values[2]);

            Vector3 ball = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));

            transform.position = ball;


            

            

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
