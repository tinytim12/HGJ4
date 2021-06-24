using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Building : MonoBehaviour
{
    public static Building buildingSelected;
    public Person personWhoLivesHere;

    public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;

    bool awake;

    public int sleepTime;

    public string[] nodeList = { "One", "Two", "Three" };

    public bool faithfulCitizen;
    public void Alert(Person p)
    {
        personWhoLivesHere = p;
        string nodeName = p.startNode + "One";
        GameHeader.Instance.playCitizen(this, nodeName);
    }

    void Update()
    {
        
    }

    public void OnUserSelect()
    {
        
        if (awake)
        {
            if (buildingSelected == this) return;
            Debug.Log("Selected");
            transform.DOPunchPosition(new Vector3(0, 0.2f, 0), 0.5f);
            buildingSelected = this;
            string nodeName = personWhoLivesHere.startNode;
            string nodeNo = nodeList[Random.Range(0, nodeList.Length)];
            GameHeader.Instance.playCitizen(this, nodeName+nodeNo);
        }
    }

    public void sleep()
    {
        awake = false;
        StartCoroutine(SleepCoroutine());
    }

    IEnumerator SleepCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(sleepTime);
        awake = true;

    }
}
