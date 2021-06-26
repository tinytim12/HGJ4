using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    public bool built;
    // Start is called before the first frame update
    public GameHeader gameHeader;
    void Start()
    {
        gameHeader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHeader>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildShrine()
    {
        if (!gameHeader.firstShrineBuilt)
        {
            gameHeader.firstShrineBuilt = true;
            gameHeader.playNarrator("ShrineBuilt");
        }
        if (!gameHeader.firstShrineBuiltAgain)
        {
            gameHeader.firstShrineBuiltAgain = true;
            gameHeader.playNarrator("ShrineTwo");
        }
        GameObject shrine = gameObject.transform.GetChild(0).gameObject;
        shrine.SetActive(true);
        built = true;
    }

    public void destroyShrine()
    {
        if (!gameHeader.firstShrineDestroyed)
        {
            gameHeader.firstShrineDestroyed = true;
            gameHeader.playNarrator("ShrineDestroyed");
        }
        GameObject shrine = gameObject.transform.GetChild(0).gameObject;
        shrine.SetActive(false);
        built = false;
    }
}
