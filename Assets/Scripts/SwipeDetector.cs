using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeDetector : MonoBehaviour
{

    public UnityEvent swipe;

    public static SwipeDetector instance { get; private set; }

    private void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2 startingPosition = new Vector2(99999, 99999);
    public Vector2 endingPosition = new Vector2(99999, 99999);

    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startingPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endingPosition = touch.position;
                swipe.Invoke();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            startingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            endingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            swipe.Invoke();
        }
        
    }
}
