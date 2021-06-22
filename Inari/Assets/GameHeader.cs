using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameHeader : MonoBehaviour
{
    public float timeRemaining;
    public Narrator narrator;
    public int day;
    public bool boy;

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
        if (timeRemaining < 10 && day == 2)
        {
            day++;
            if (narrator != null)
            {
                narrator.play();
            }

        }
        if (timeRemaining < 45 && day ==1)
        {
            day++;
            if (narrator != null)
            {
                narrator.play();
 
            }
            
        }
        
    }


    [YarnCommand("getDay")]
    public int getDay()
    {
        return day;
    }

    public bool getBoy()
    {
        return boy;
    }

    public void setBoy(bool val)
    {
        boy = val;
    }

    //0 = Merchant
    //1 = Prostitute
    //2 = Blacksmith
    //3 = Thief
    //4 = Government
    //5 = Westerner
    //6 = Boy
    public void createPerson(int number)
    {
        GameObject person = Instantiate(personPrefab);
        //add whatever meshes or other components here
        Debug.Log(yarnScripts[0]);
        YarnProgram [] yarnList = new YarnProgram[1];
        yarnList[0] = yarnScripts[number];
        person.transform.GetChild(0).transform.GetChild(0).GetComponent<Yarn.Unity.DialogueRunner>().yarnScripts = yarnList;
    }
    

}
