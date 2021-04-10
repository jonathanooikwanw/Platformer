using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour { 

	public int offsetX = 2;         // the offset so that we don't get any weird errors

// these are used for checking if we need to instantiate stuff
	public bool hasARightSide = false;
	public bool hasALeftSide = false;

	public bool reverseScale = false;   // used if the object is not tilable

	private float spriteWidth = 0f;     // the width of our element
	private Camera cam;
	private Transform myTransform;

void Awake()
{
	cam = Camera.main;
	myTransform = transform;
}

		// Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}

    // Update is called once per frame
    void Update()
    {
		// does it still need buddies? If not do nothing
		if (hasALeftSide == false || hasARightSide == false)
		{
			// calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			// calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			// checking if we can see the edge of the element and then calling MakeNewBuddy if we can
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightSide == false)
			{
				MakeNewSide(1);
				hasARightSide = true;
			}
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftSide == false)
			{
				MakeNewSide(-1);
				hasALeftSide = true;
			}
		}
	}
	// a function that creates a buddy on the side required
	void MakeNewSide(int rightOrLeft)
	{
		// calculating the new position for our new buddy
		Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		// instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

		// if not tilable let's reverse the x size og our object to get rid of ugly seams
		if (reverseScale == true)
		{
			newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0)
		{
			newBuddy.GetComponent<Tiling>().hasALeftSide = true;
		}
		else
		{
			newBuddy.GetComponent<Tiling>().hasARightSide = true;
		}
	}
}

