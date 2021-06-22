using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Person personWhoLivesHere;
    
    public void Alert()
    {
        GameHeader.Instance.playCitizen(personWhoLivesHere);
    }
}
