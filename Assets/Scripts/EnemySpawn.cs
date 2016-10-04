using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    float maxSpawnRate = 5f;

	// Use this for initialization
	void Start ()
    {
        Invoke("Spawn", maxSpawnRate);
        InvokeRepeating("IncreaseDificulty", 0f, 30f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject Enemy1 = (GameObject)Instantiate(Enemy);
        Enemy1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        NewEnemySpawn();

    }

    void NewEnemySpawn()
    {
        float _Spawn;
        if (maxSpawnRate > 1f)
        {
            _Spawn = Random.Range(1f, maxSpawnRate);
        }
        else
        {
            _Spawn = 1f;
        }
        Invoke("Spawn", _Spawn);
    }

    void IncreaseDificulty()
    {
        if (maxSpawnRate > 1f)
        {
            maxSpawnRate--;
        }
        if (maxSpawnRate == 1f)
        {
            CancelInvoke("IncreaseDificulty");
        }
    }
}
