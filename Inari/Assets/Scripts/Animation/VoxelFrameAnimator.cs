using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: Put the gameobjects underneath a parent object with this component attatched. the gameobjects will be activated in order, those are the frames.
public class VoxelFrameAnimator : MonoBehaviour
{
    [SerializeField] private float secondsPerFrame;
    private int _currentFrame = 0;

    void Start()
    {
        InvokeRepeating(nameof(NextFrame), secondsPerFrame, secondsPerFrame);        
    }

    private void NextFrame()
    {
        if(_currentFrame < transform.childCount)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            transform.GetChild(_currentFrame).gameObject.SetActive(true);

            _currentFrame++;
        }
        else
        {
            _currentFrame = 0;
        }
    }

}
