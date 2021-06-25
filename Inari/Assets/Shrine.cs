using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    public bool built;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildShrine()
    {
        GameObject shrine = gameObject.transform.GetChild(0).gameObject;
        shrine.SetActive(true);
        built = true;
    }

    public void destroyShrine()
    {
        GameObject shrine = gameObject.transform.GetChild(0).gameObject;
        shrine.SetActive(false);
        built = false;
    }
}
