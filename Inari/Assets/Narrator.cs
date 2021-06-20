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
    void Start()
    {
        text = this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        Debug.Log("hit");
        enableText();
        

    }
    private void enableText ()
    {
        text.enabled = true;
        dialogueRunner.StartDialogue();
        //StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                text.color = new Color(1, 1, 1, i);
                yield return new WaitForSeconds(3);
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                text.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    public void disableText()
    {
        StartCoroutine(FadeImage(false));
        text.enabled = false;
        
    }
}
