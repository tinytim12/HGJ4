using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Person : MonoBehaviour
{
    public YarnProgram[] yarnScripts;
    // Start is called before the first frame update
    void Start() {
        transform.GetChild(0).transform.GetChild(0).GetComponent<DialogueRunner>().yarnScripts = yarnScripts;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
