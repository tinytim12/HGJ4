using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Building : MonoBehaviour
{
    public static Building buildingSelected;
    public Person personWhoLivesHere;


    public GameObject icon;
    public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;

    bool awake;

    public int sleepTime;

    public string[] nodeList = { "One", "Two", "Three" };

    public bool faithfulCitizen;

    private void Start()
    {
        icon.SetActive(false);
    }
    public void Alert(Person p)
    {
        personWhoLivesHere = p;
        icon.SetActive(true);
        awake = true;
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
        icon.SetActive(false);
        awake = false;
        StartCoroutine(SleepCoroutine());
    }

    IEnumerator SleepCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(sleepTime);
        awake = true;
        icon.SetActive(true);
    }
}
