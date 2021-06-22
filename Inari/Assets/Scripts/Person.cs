using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System;
using Yarn.Unity;

[CreateAssetMenu()]
public class Person : ScriptableObject
{
    public YarnProgram[] dialogueRunnerScripts;
    public string startNode;
}
