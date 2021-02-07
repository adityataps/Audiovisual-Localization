using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSpotlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color spotlightColor = new Color(1f, 1f, 1f, 0.01f);
        this.GetComponent<Renderer>().material.color = spotlightColor;
        //this.GetComponent<Renderer>().material.
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ballProperties>().setTransparency(0.01f);
        Debug.Log("collision");

    }

    // ontriggerenter


}
