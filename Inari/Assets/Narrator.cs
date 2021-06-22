using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;


public class Narrator : MonoBehaviour
{
    // Start is called T
    public Text text;
    public DialogueRunner dialogueRunner;
    public DialogueUI dialogueUI;
    public InMemoryVariableStorage varStorage;
    public GameHeader gameHeader;
    void Start()
    {
        text = this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        dialogueRunner = GameObject.FindGameObjectWithTag("NarratorDialogue").GetComponent<DialogueRunner>();
        dialogueUI = GameObject.FindGameObjectWithTag("NarratorDialogue").GetComponent<DialogueUI>();
        varStorage = GameObject.FindGameObjectWithTag("NarratorDialogue").GetComponent<InMemoryVariableStorage>();
        gameHeader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHeader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        enableText(); 

    }
    private void enableText ()
    {
        text.enabled = true;
        dialogueRunner.StartDialogue();
        StartCoroutine(FadeImage(1));




    }

    IEnumerator FadeImage(float t)
    {
        // fade from opaque to transparent
        
   
        // loop over 1 second backwards
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }

        
        // fade from transparent to opaque
        yield return new WaitForSeconds(4);
            // loop over 1 second

        while (text.color.a > 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }

        dialogueUI.MarkLineComplete();
        if (dialogueRunner.IsDialogueRunning)
        {
            Debug.Log("Hit dialogue");

            StartCoroutine(FadeImage(1));
            if (!gameHeader.getBoy())
            {
                gameHeader.setBoy(true);
                gameHeader.createPerson(6);
            }
        }
        else
        {
            Debug.Log("Esaped");
            

            varStorage.SetValue("$day", gameHeader.getDay());

        }

    }


    public void disableText()
    {
        //StartCoroutine(FadeImage(false));
        text.enabled = false;
        
    }
}
