using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

	public GameObject platformDestroyer;
    // Start is called before the first frame update
    void Start()
    {
		platformDestroyer = GameObject.Find("PlatformDestructionPoint"); //assign the gameobject to platformDestroyer
    }

    // Update is called once per frame
    void Update()
    {
		//if current platform x position is behind the platformdestroyer point, it will be destroyed
        if(transform.position.x < platformDestroyer.transform.position.x)
		{
			Destroy(gameObject);
		}
    }
}
