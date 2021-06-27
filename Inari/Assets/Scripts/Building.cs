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
    public Vector3 requestIconPosition = new Vector3(-0.583f, 2.42f, 0);

    public GameHeader gameHeader;
    bool awake;

    public int sleepTime;

    public string[] nodeList = { "One", "Two", "Three" };

    public bool faithfulCitizen;
    private GameObject _icon;

    private void Start()
    {
        _icon = Instantiate(icon, transform);
        _icon.transform.localPosition = requestIconPosition;
        _icon.SetActive(false);

        gameHeader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHeader>();
    }

    private void Update()
    {
        // slowly move icon up and down
        _icon.transform.Translate(0, Mathf.Sin(Time.time * 2f) * 0.006f, 0, Space.Self);
    }


    public void Alert(Person p)
    {
        personWhoLivesHere = p;
        _icon.SetActive(true);
        awake = true;
    }

    public void OnUserSelect()
    {
        if (awake)
        {
            if (buildingSelected == this) return;

            Debug.Log("Selected");
            
            transform.DOPunchPosition(new Vector3(0, 0.2f, 0), 0.5f);

            
            gameHeader.citizenNumber++;

            buildingSelected = this;
            string nodeName = personWhoLivesHere.startNode;
            string nodeNo = nodeList[Random.Range(0, nodeList.Length)];
            GameHeader.Instance.playCitizen(this, nodeName+nodeNo);
        }
    }

    public void sleep()
    {
        _icon.SetActive(false);
        awake = false;
        StartCoroutine(SleepCoroutine());
    }

    IEnumerator SleepCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        sleepTime = Random.Range(10, 15);
        yield return new WaitForSeconds(sleepTime);
        awake = true;
        _icon.SetActive(true);
    }
}
