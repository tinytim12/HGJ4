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
    public float timeRemaining;
    public Person narrator;
    public Person[] persons;

    public YarnProgram citizenDialogue;
    public YarnProgram narratorDialogue;

    public int day;
    public int shrinePoints;
    public int antiShrinePoints;

    public DialogueRunner dialogueRunner;
    public DialogueUI dialogueUI;
    public Text dialogueText;
    public Blessings blessings;

    public DialogueRunner dialogueRunnerNarrator;
    public DialogueUI dialogueUINarrator;
    public Text dialogueTextNarrator;

    public float hunger;
    public float fortune;
    public float maxHunger;
    public float maxFortune;

    bool fading;

    public bool firstBlessed;
    public bool firstCursed;
    public bool firstShrineBuilt;
    public bool firstShrineDestroyed;
    public bool firstShrineBuiltAgain;

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
        dialogueRunner.Add(citizenDialogue);
        dialogueRunnerNarrator.Add(narratorDialogue);

        onDayChanged += OnDayChanged;

        day = 1;

        playNarrator("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hunger <= 0)
        {
            playNarrator("Win");
        }
        checkShrines();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining < 810 && day == 6)
        {
            day++;
            onDayChanged(day);
        }
        else if (timeRemaining < 860 && day == 5)
        {
            day++;
            onDayChanged(day);

        }
        else if (timeRemaining < 910 && day == 4)
        {
            playNarrator("Warning");
            day++;
            onDayChanged(day);
        }
        else if (timeRemaining < 950 && day == 3)
        {
            day++;
            onDayChanged(day);

        }
        else if (timeRemaining < 980 && day == 2)
        {
            day++;
            onDayChanged(day);
        }
        else if (timeRemaining < 990 && day == 1)
        {
            Debug.Log("New Day");
            day++;
            onDayChanged(day);
        }
    }

    void checkShrines()
    {
        if(shrinePoints > 3)
        {
            hunger -= 10;
            //build shrine
            List<Shrine> shrines = new List<Shrine>();
            foreach (var shrine in FindObjectsOfType<Shrine>())
            {
                if (!shrine.built)
                {
                    shrines.Add(shrine);
                    
                }
            }

            
            if (shrines.Count != 0)
            {
                Shrine randomShrine = shrines[Random.Range(0, shrines.Count)];
                StartCoroutine(waitForShrine(randomShrine, true));
            }
            shrinePoints = 0;
        }
        if(antiShrinePoints > 10)
        {
            hunger -= 10;
            List<Shrine> shrines = new List<Shrine>();
            foreach (var shrine in FindObjectsOfType<Shrine>())
            {
                if (shrine.built)
                {
                    shrines.Add(shrine);
                }
            }


            if (shrines.Count != 0)
            {
                Shrine randomShrine = shrines[Random.Range(0, shrines.Count)];
                StartCoroutine(waitForShrine(randomShrine, false));
            }
            shrinePoints = 0;
        }
    }

    private void OnDayChanged(int newDay)
    {
        //add person to empty building
        List<Building> buildings = new List<Building>();
        foreach (var building in FindObjectsOfType<Building>())
        {
            if(building.personWhoLivesHere == null)
            {
                buildings.Add(building);
            }
        }
        
        if(buildings.Count != 0)
        {
            Building randomBuilding = buildings[Random.Range(0, buildings.Count)];
            Person p = persons[Random.Range(0, day)];
            randomBuilding.Alert(p);
        }

        
    }

    public void playNarrator(string line)
    {
        StartCoroutine(waitforDialogueNarrator(line));


    }

    public void playCitizen(Building building, string line)
    {
        Person person = building.personWhoLivesHere;
        dialogueRunner.StartDialogue(line);

        blessings.building = building;

    }
    
    IEnumerator FadeImage(float t)
    {
        // fade from opaque to transparent
        fading = true;
        // loop over 1 second backwards
        dialogueTextNarrator.color = new Color(dialogueTextNarrator.color.r, dialogueTextNarrator.color.g, dialogueTextNarrator.color.b, 0);
        while (dialogueTextNarrator.color.a < 1.0f)
        {
            dialogueTextNarrator.color = new Color(dialogueTextNarrator.color.r, dialogueTextNarrator.color.g, dialogueTextNarrator.color.b, dialogueTextNarrator.color.a + (Time.deltaTime / t));
            yield return null;
        }

        
        // fade from transparent to opaque
        yield return new WaitForSeconds(4);

        while (dialogueTextNarrator.color.a > 0)
        {
            dialogueTextNarrator.color = new Color(dialogueTextNarrator.color.r, dialogueTextNarrator.color.g, dialogueTextNarrator.color.b, dialogueTextNarrator.color.a - (Time.deltaTime / t));
            yield return null;
        }
        fading = false;
        dialogueUINarrator.MarkLineComplete();
        if (dialogueRunnerNarrator.IsDialogueRunning)
        {
            StartCoroutine(FadeImage(1));

        }
    }

    IEnumerator waitForShrine(Shrine shrine, bool building)
    {
        Debug.Log("Shrine building");
        yield return new WaitForSeconds(5);
        if (building)
        {
            shrine.buildShrine();
        }
        else
        {
            shrine.destroyShrine();
        }

    }

    IEnumerator waitforDialogueNarrator(string line)
    {
        //Cutscene Stuff
        Debug.Log("Waiting");

        while (dialogueRunnerNarrator.IsDialogueRunning || fading)
        {

            yield return null;
        }
        //More Cutscene Stuff and End the cutscene
        Debug.Log("dialogue cued");
        dialogueRunnerNarrator.StartDialogue(line);
        StartCoroutine(FadeImage(1));
    }



}
