using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platfromStart;
    public Transform player;
    private Vector3 playerStart;

    private PlatformDestroyer[] platformDestroyers;

	// Use this for initialization
	void Start ()
    {
        platfromStart = platformGenerator.position;
        playerStart = player.position;
	}
	
	// Update is called once per frame
	void Update ()
    {        
		
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
		//Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene);
	}

    public IEnumerator RestartGameCo()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformDestroyers = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformDestroyers.Length; i++)
        {
            platformDestroyers[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStart;
        platformGenerator.transform.position = platfromStart;
        player.gameObject.SetActive(true);
    }
}
