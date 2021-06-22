using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessings : MonoBehaviour

{
    public int divinityBlessing;
    public int fortuneBlessing;
    public int divinityCurse;
    public int fortuneCurse;

    public GameHeader gameHeader;
    // Start is called before the first frame update
    void Start()
    {
        gameHeader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHeader>();
    }


    public void Blessing()
    {
        //divinity inCrease is initially small. Shrine should 
        gameHeader.divinity += divinityBlessing;
        gameHeader.fortune += fortuneBlessing;
    }

    public void Curse()
    {
        gameHeader.divinity += divinityCurse;
        gameHeader.fortune += fortuneCurse;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
