using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System;
using Yarn.Unity;

[CreateAssetMenu()]
public class Person : ScriptableObject
{

    public YarnProgram dialogueRunnerScript;
    public string startNode;
    public bool faithfulCitizen;

    public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;

    GameHeader gameHeader;
   
}
