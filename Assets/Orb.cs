using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private static readonly int ShaderColor = Shader.PropertyToID("_Color");
    private GameObject _assassin, _protector, _manager;
    private int _orbID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var assassinPos = _assassin.transform.position;
        var assassinX = assassinPos.x;
        var assassinY = assassinPos.y;
        var distanceToAssassin = CalculateDistance(assassinX, assassinY);
        var angleToAssassin = CalculateAngle(assassinX, assassinY);
        
        var protectorPos = _protector.transform.position;
        var protectorX = protectorPos.x;
        var protectorY = protectorPos.y;
        var distanceToProtector = CalculateDistance(protectorX, protectorY);
        var angleToProtector = CalculateAngle(protectorX, protectorY);

        if (gameObject.GetComponent<Renderer>().material.GetColor(ShaderColor) == Color.blue)
        {
            Debug.Log("DA: " + distanceToAssassin + "\nAA: " + angleToAssassin+ "\nDP: " + distanceToProtector + "\nAP: " + angleToProtector);
            Debug.Log(CheckAngleError(angleToAssassin, angleToProtector));
        }

        




    }

    public void AssignAssassin(GameObject orb)
    {
        _assassin = orb;
    }

    public void AssignProtector(GameObject orb)
    {
        _protector = orb;
    }

    public void AssignManager(GameObject manager)
    {
        _manager = manager;
    }
    
    public void AssignOrbID(int id)
    {
        _orbID = id;
    }
    
    private void OnMouseDown()
    {
        if (!_manager.GetComponent<Manager>().clearOrbColors()) return;
        SetMainCharacterColor();
        _assassin.GetComponent<Orb>().SetAssassinColor();
        _protector.GetComponent<Orb>().SetProtectorColor();
    }

    public void SetMainCharacterColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor(ShaderColor, Color.blue);

    }

    public void SetProtectorColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor(ShaderColor, Color.green);
    }

    public void SetAssassinColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor(ShaderColor, Color.red);
    }

    public void SetHoiPaloiColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor(ShaderColor, Color.white);

    }

    public double CalculateDistance(float x2, float y2)
    {
        var pos = transform.position;
        var x1 = pos.x;
        var y1 = pos.y;
        var distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        return distance;
    }

    public double CalculateAngle(float x2, float y2)
    {        
        var pos = transform.position;
        var x1 = pos.x;
        var y1 = pos.y;
        var m = (y2 - y1) / (x2 - x1);
        //var angle = Math.Atan(m) * 180/Math.PI;
        double angle = (float)((Mathf.Atan2(y2-y1, x2-x1) / Math.PI) * 180f);
        if(angle < 0) angle += 360f;
        return angle;
    }

    public bool CheckAngleError(double a1, double a2)
    {
        return Math.Abs(a1 - a2) < 0.1;
    }
}
