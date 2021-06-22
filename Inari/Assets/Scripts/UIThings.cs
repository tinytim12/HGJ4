using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIThings : MonoBehaviour
{
    [SerializeField] private Transform escapeMenu;

    private void Awake()
    {
        CloseEscapeMenu();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeMenu.gameObject.activeInHierarchy)
            {
                CloseEscapeMenu();
            }
            else
            {
                OpenEscapeMenu();
            }
        }
    }

    public void OpenEscapeMenu()
    {
        escapeMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseEscapeMenu()
    {
        escapeMenu.gameObject.SetActive(false);
        Time.timeScale = 1f; 
    }
    public void Quit()
    {
        Application.Quit();
    }
}
