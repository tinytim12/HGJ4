using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class GameHeader : MonoBehaviour
{
    public static GameHeader Instance;
    public delegate void OnDayChange(int newDay);
    public OnDayChange onDayChanged;
    public float timeRemaining = 10;
    public Person narrator;
    public Person[] persons;

    public int day;
    public DialogueRunner dialogueRunner;
    public DialogueUI dialogueUI;
    public Text dialogueText;
    public Blessings blessings;

    public DialogueRunner dialogueRunnerNarrator;
    public DialogueUI dialogueUINarrator;
    public Text dialogueTextNarrator;

    public int divinity;
    public int fortune;

    

private void Awake()
    {
        // Create singleton to easily access GameHeader from other scripts

        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        onDayChanged += OnDayChanged;

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
            onDayChanged(day);

        }
        else if (timeRemaining < 45 && day ==1)
        {
            day++;
            onDayChanged(day);
        }
    }

    private void OnDayChanged(int newDay)
    {

        Building[] buildings = FindObjectsOfType<Building>();
        if(buildings.Length == 0) return;

        Building randomBuilding = buildings[Random.Range(0, buildings.Length)];
        Person p = persons[Random.Range(0, day)];
        randomBuilding.Alert(p);
    }

    public void playNarrator(Person person)
    {
        dialogueRunnerNarrator.startNode = person.startNode;
        dialogueRunnerNarrator.yarnScripts = person.dialogueRunnerScripts;
        dialogueRunnerNarrator.Load();
        dialogueRunnerNarrator.StartDialogue();
        StartCoroutine(FadeImage(1));

    }

    public void playCitizen(Person person, string line)
    {
        dialogueRunner.startNode = person.startNode;
        dialogueRunner.yarnScripts = person.dialogueRunnerScripts;
        dialogueRunner.Load();
        dialogueRunner.StartDialogue(line);

        blessings.divinityBlessing = person.divinityBlessing;
        blessings.fortuneBlessing = person.fortuneBlessing;
        blessings.divinityCurse = person.divinityCurse;
        blessings.fortuneCurse = person.fortuneCurse;
    }
    
    IEnumerator FadeImage(float t)
    {
        // fade from opaque to transparent
   
        // loop over 1 second backwards
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0);
        while (dialogueText.color.a < 1.0f)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a + (Time.deltaTime / t));
            yield return null;
        }

        
        // fade from transparent to opaque
        yield return new WaitForSeconds(4);
            // loop over 1 second

        while (dialogueText.color.a > 0)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - (Time.deltaTime / t));
            yield return null;
        }
        dialogueUI.MarkLineComplete();
    }

    

}
