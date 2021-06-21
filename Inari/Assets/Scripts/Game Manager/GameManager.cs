using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]internal float hunger;
    [SerializeField]internal float luck;
    void Start()
    {
        hunger = 1;
        luck = 1;
    }

    void Update()
    {
        hunger = Mathf.Clamp(hunger, 0, 1);
        luck= Mathf.Clamp(luck, 0, 1);
    }
    public void modifyStats(string stat,float valueModify)
    {
        switch (stat)
        {
            case "hunger":
                hunger += valueModify;
                break;
            case "luck":
                luck += valueModify;
                break;
            default:
                Debug.LogError("The name of the stat is wrong.");
                break;
        }
    }
}
