using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHeader : MonoBehaviour
{
    public float timeRemaining = 10;
    public Narrator narrator;
    public int day;

    public GameObject personPrefab;
    public YarnProgram[] yarnScripts;

    // Start is called before the first frame update
    void Start()
    {
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining < 8 && day ==1)
        {
            day++;
            if (narrator != null)
            {
                narrator.play();
            }
            
        }
    }

    int getDay()
    {
        return day;
    }

    public void Merchant()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here
        
        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[0];
        

        //Or if you do create prefabs, just instantiate them here instead
    }

    public void Prostitute()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here

        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[1];
    }

    public void Blacksmith()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here

        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[2];
    }

    public void Thief()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here

        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[3];
    }

    public void Government()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here

        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[4];
    }

    public void Westerner()
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here

        person.GetComponent<Person>().dialogueRunnerScripts[0] = yarnScripts[5];
    }

}
