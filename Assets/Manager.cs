using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject prefabOrb;
    private List<GameObject> _orbsList;
    private int _cols, _rows;
    
    // Start is called before the first frame update
    void Start()
    {
        _cols = 8;
        _rows = 8;
        _orbsList = PlaceOrbs();
        AssignRelationships();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<GameObject> PlaceOrbs()
    {
        List<GameObject> orbs = new List<GameObject>();
        for (int columns = 0; columns < _cols; columns++)
        {
            for (int rows = 0; rows < _rows; rows++)
            {
                var new_orb = Instantiate(prefabOrb);
                new_orb.transform.position = new Vector2(columns-8, rows - 4);
                var orbID = orbs.Count + 1;
                new_orb.GetComponent<Orb>().AssignManager(gameObject);
                new_orb.GetComponent<Orb>().AssignOrbID(orbID);
                orbs.Add(new_orb);
            }
        }
        return orbs;
    }

    void AssignRelationships()
    {
        for (int i = 0; i < _orbsList.Count; i++)
        {
            var protectorNum = 0;
            var assassinNum = 0;
            while (protectorNum == assassinNum || assassinNum == i || protectorNum == i)
            { 
                protectorNum = Random.Range(0, _orbsList.Count);
                assassinNum = Random.Range(0, _orbsList.Count);
            }

            var assassin = _orbsList[assassinNum];
            var protector = _orbsList[protectorNum];
            var mainCharacter = _orbsList[i];
            
            mainCharacter.GetComponent<Orb>().AssignAssassin(assassin);
            mainCharacter.GetComponent<Orb>().AssignProtector(protector);
        }
    }

    public bool clearOrbColors()
    {
        foreach (var orb in _orbsList)
        {
            orb.GetComponent<Orb>().SetHoiPaloiColor();
        }
        return true;
    }
}
