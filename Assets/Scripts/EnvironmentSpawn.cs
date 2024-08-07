using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawn : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn= spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }

    public void OnDestroy()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("environment"))
        {
            Destroy(o);
        }
    }

}
