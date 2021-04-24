using System.Collections;
using System.Collections.Generic;
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
    void Update(){
        
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
}
