using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ballProperties : MonoBehaviour
{

    private string congruencyCondition;     // congruent or incongruent?
    private string ballType;                // response vs actual?
    private double responseTime;            // response time
    private double angleOffset;             // angle offset
    public double alpha;                    // transparency


    public string getCongruencyCondition()
    {
        return this.congruencyCondition;
    }

    public void setCongruencyCondition(string newCondition)
    {
        this.congruencyCondition = newCondition;
    }

    public string getBallType()
    {
        return this.ballType;
    }

    public void setBallType(string newType)
    {
        this.ballType = newType;
    }

    public double getResponseTime()
    {
        return this.responseTime;
    }

    public void setResponseTime(double newTime)
    {
        this.responseTime = newTime;
    }

    public double getAngleOffset()
    {
        return this.angleOffset;
    }

    public void setAngleOffset(double newAngle)
    {
        this.angleOffset = newAngle;
    }

    public double getTransparency()
    {
        return alpha;
    }

    public void setTransparency(double newAlpha)
    {
        this.alpha = newAlpha;
        MeshRenderer meshR = this.GetComponent<MeshRenderer>();
        Color newColor;
        if (this.ballType.Equals("Actual"))
        {
            newColor = new Color(0f, 0f, 1f, (float)newAlpha);
        }
        else if (this.congruencyCondition.Equals("Congruent"))
        {
            newColor = new Color(0f, 1f, 0f, (float)newAlpha);
        }
        else if (this.congruencyCondition.Equals("Incongruent"))
        {
            newColor = new Color(1f, 0f, 0f, (float)newAlpha);
        } else
        {
            newColor = new Color(1f, 1f, 1f, (float)newAlpha);
        }

    }






    // Start is called before the first frame update
    void Start()
    {
        //pullTrigger();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
