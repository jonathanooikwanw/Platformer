 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
	public GameObject platform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
    // Start is called before the first frame update
    void Start()
    {
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x; //gets the length of the platform
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
		{
			//randomizes the distance between platforms
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
			//creates copy of existing object
			Instantiate(platform, transform.position, transform.rotation);
		}
    }
}
