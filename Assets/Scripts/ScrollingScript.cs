using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

    public Vector2 Speed = new Vector2(2, 2);
    public Vector2 Direction = new Vector2(-1, 0);
    public bool IsLinkedToCamera = false;
    public bool IsLooping = false;

    private List<Transform> _backgroundParts;

	// Use this for initialization
	void Start () {
	    if (IsLooping)
	    {
	        _backgroundParts = new List<Transform>();
	        for (int i = 0; i < transform.childCount; i++)
	        {
	            Transform child = transform.GetChild(i);

	            if (child.renderer != null)
	            {
	                _backgroundParts.Add(child);
	            }
	        }

            // order from left to right
	        _backgroundParts = _backgroundParts.OrderBy(t => t.position.x).ToList();
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 movement = new Vector3(Speed.x * Direction.x, Speed.y * Direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera
	    if (IsLinkedToCamera)
	    {
	        Camera.main.transform.Translate(movement);
	    }

	    if (IsLooping)
	    {
	        Transform firstChild = _backgroundParts.FirstOrDefault();
	        if (firstChild != null)
	        {
	            // Check if child has already passed the left bound of the camera
	            if (firstChild.position.x < Camera.main.transform.position.x)
	            {
	                // See if child is completely to the left of camera, and therefore needs to be recycled
	                if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
	                {
	                    Transform lastChild = _backgroundParts.LastOrDefault();
	                    Vector3 lastPosition = lastChild.transform.position;
	                    Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                        // set position to be after last child
                        firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

	                    _backgroundParts.Remove(firstChild);
                        _backgroundParts.Add(firstChild);
	                }
	            }
	        }

	    }
	}
}
