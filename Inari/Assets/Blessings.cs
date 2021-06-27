using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Blessings : MonoBehaviour

{
    /*public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;
    */

    public bool good;

    public GameHeader gameHeader;

    public Building building;

    public DialogueUI dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        gameHeader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHeader>();
    }


    public void Blessing()
    {
        //divinity inCrease is initialy small
        Person person = building.personWhoLivesHere;
        gameHeader.hunger -= person.hungerPoint;
        gameHeader.fortune -= person.fortunePoint;
        if (person.faithfulCitizen){
            gameHeader.shrinePoints++;
        }
        building.sleep();
        dialogueUI.MarkLineComplete();

        if (!gameHeader.firstBlessed)
        {
            gameHeader.firstBlessed = true;
            gameHeader.playNarrator("Bless");
        }
    }

    public void Curse()
    {
        Person person = building.personWhoLivesHere;
        gameHeader.fortune += person.fortunePoint;
        building.sleep();
        dialogueUI.MarkLineComplete();
        if (person.faithfulCitizen)
        {
            gameHeader.antiShrinePoints--;
        }

        if (!gameHeader.firstCursed)
        {
            gameHeader.firstCursed = true;
            gameHeader.playNarrator("Curse");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
