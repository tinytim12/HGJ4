using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using Yarn.Unity;
=======
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using CsvHelper;
using System;
>>>>>>> Stashed changes

public class Person : MonoBehaviour
{
    public YarnProgram[] yarnScripts;
    // Start is called before the first frame update
    void Awake() {
        transform.GetChild(0).transform.GetChild(0).GetComponent<Yarn.Unity.DialogueRunner>().yarnScripts = yarnScripts;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
