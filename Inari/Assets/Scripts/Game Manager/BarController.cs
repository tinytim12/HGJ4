using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] GameObject hungerValue;
    [SerializeField] GameObject luckValue;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    void Update()
    {
        SetBarValue(hungerValue, gameManager.hunger);
        SetBarValue(luckValue, gameManager.luck);

    }
    void SetBarValue(GameObject bar, float value)
    {
        bar.transform.localScale = new Vector2(value,1);
    }
}
