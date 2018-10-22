using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    //parameters
    [SerializeField] int breakableBlocks; //can be used for debugging purposes

    //cache reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        ++breakableBlocks;
    }

    public void BlockDestroyed()
    {
        --breakableBlocks;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadMainScene();
        }
    }


}
