using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour {

    GameSession destroy;

	public void MainScene()
    {
        destroy = FindObjectOfType<GameSession>();

        SceneManager.LoadScene(0);
        destroy.DestroyScene();
    }
	
}
