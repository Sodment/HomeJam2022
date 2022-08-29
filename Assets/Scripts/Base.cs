using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public BaseType baseType;


    public void SendParticles(Vector3 target)
    {
        Component[] particles = gameObject.GetComponentsInChildren(typeof(Particle));
        Debug.Log(particles.Length);
        foreach (Component p in particles)
        {
            Debug.Log(p.gameObject.name);

            LeanTween.move(p.gameObject, RandomPointInCircle(target), 3.0f).setOnComplete(() => Destroy(p.gameObject));
        }
    }

    public Vector3 RandomPointInCircle(Vector3 target)
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        Vector3 rp = new Vector3(randomPoint.x, randomPoint.y, 0.0f) * 0.25f;
        return (target + rp);
    }
}


