using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipedOverNode : MonoBehaviour
{

    private Vector2 myPosition;
    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
        SwipeDetector.instance.swipe.AddListener(CheckSwipePlace);
    }

    public float distance = 0.0f;

    // Update is called once per frame
    private void CheckSwipePlace()
    {
        if (Vector2.Distance(myPosition, SwipeDetector.instance.startingPosition) < 1)
        {
            Debug.Log("Im starting here: "  + gameObject.name);
            //distance = Vector2.Distance(myPosition, SwipeDetector.instance.startingPosition);
        }
        
        
        if (Vector2.Distance(myPosition, SwipeDetector.instance.endingPosition) < 1)
        {
            Debug.Log("Im ending here: "  + gameObject.name);
            //distance = Vector2.Distance(myPosition, SwipeDetector.instance.endingPosition);
        }
    }
}
