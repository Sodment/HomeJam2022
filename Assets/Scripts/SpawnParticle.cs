using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public float spawnTimer;
    public float radius;
    public GameObject particlePrefab;
    public short particleLimit = 40;
    private short aliveParticles = 0;
    float timer = 0.0f;
    void Update()
    {
        if (timer >= spawnTimer && aliveParticles < particleLimit)
        {
            Instantiate(particlePrefab, RandomPointOnCircle(), Quaternion.identity, gameObject.transform);
            timer = 0.0f;
            aliveParticles += 1;
        }
        timer += Time.deltaTime;
    }

    Vector3 RandomPointOnCircle()
    {
        var vector2 = transform.position + Random.onUnitSphere.normalized * radius;
        return new Vector3(vector2.x, vector2.y, 0);
    }
}
