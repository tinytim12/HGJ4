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

    public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;

    GameHeader gameHeader;
    void Start()
    {
        gameHeader = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GameHeader>();
    }
    void Blessing()
    {
        //divinity inCrease is initially small. Shrine should 
        gameHeader.divinity += divinityBlessing;
        gameHeader.fortune += fortuneBlessing;
    }

    void Curse()
    {
        gameHeader.divinity += divinityCurse;
        gameHeader.fortune += fortuneCurse;
    }
}
