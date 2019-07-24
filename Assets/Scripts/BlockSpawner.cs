using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    private float timeToSpawn = 2f;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawnBlocks();
        timeToSpawn = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn<0f)
        {
            timeToSpawn = 2f;
            RandomSpawnBlocks();
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }
    void RandomSpawnBlocks()
    {
        int randomIndex = Random.Range(0,spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i!=randomIndex)
            {
                GameObject blockClone = Instantiate(blockPrefab,spawnPoints[i].position,Quaternion.identity);
                blockClone.GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 50f;
                Destroy(blockClone,3f);
            }
        }
    }
}
