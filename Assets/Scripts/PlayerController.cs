using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameManager gameManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.RestartGame();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
