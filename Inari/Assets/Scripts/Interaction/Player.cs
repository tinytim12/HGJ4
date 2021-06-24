using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.Linq;

public class Player : MonoBehaviour
{
    public DialogueRunner[] dialogueRunner;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dialogueRunner.Any(x => x.IsDialogueRunning)) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Building building = hit.collider.GetComponentInParent<Building>();
                if (building) building.OnUserSelect();
            }
            
        }
    }

}
