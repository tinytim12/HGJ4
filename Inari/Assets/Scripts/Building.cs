using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Building : MonoBehaviour
{
    public static Building buildingSelected;
    public Person personWhoLivesHere;
    
    public void Alert(Person p)
    {
        personWhoLivesHere = p;
        GameHeader.Instance.playCitizen(personWhoLivesHere, "One");
    }

    public void OnUserSelect()
    {
        if(buildingSelected == this) return;

        transform.DOPunchPosition(new Vector3(0, 0.2f, 0), 0.5f);
        buildingSelected = this;
    }
}
