using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour
{
    public GameObject EnemyBullet;

	// Use this for initialization
	void Start ()
    {
        Invoke("Fire", 1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position-bullet.transform.position;
            bullet.GetComponent<EnemyBulletController>().SetDirection(direction);
        }
    }
}
