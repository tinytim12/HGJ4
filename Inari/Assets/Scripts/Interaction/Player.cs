using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!dialogueRunner.IsDialogueRunning)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Building building = hit.collider.GetComponentInParent<Building>();
                    if (building) building.OnUserSelect();
                }
            }
            
        }
    }

}
