using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipedOverNode : MonoBehaviour
{
    public List<GameObject> bases;
    // Start is called before the first frame update
    void Start()
    {
        SwipeDetector.instance.swipe.AddListener(CheckSwipePlace);
    }

    // Update is called once per frame
    private void CheckSwipePlace()
    {
        GameObject startingGO = null;
        GameObject endingGO = null;
        foreach (GameObject go in bases)
        {
            if (Vector2.Distance(go.transform.position, SwipeDetector.instance.startingPosition) < 1)
            {
                //Debug.Log("DUPA");
                startingGO = go;
            }
            if (Vector2.Distance(go.transform.position, SwipeDetector.instance.endingPosition) < 1)
            {
                //Debug.Log("DUPA 2");
                endingGO = go;
            }
        }
        if (startingGO != null && endingGO != null && startingGO != endingGO)
        {
            startingGO.GetComponent<Base>().SendParticles(endingGO.transform.position);
        }
    }
}
