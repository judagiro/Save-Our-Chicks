using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletPosition;
    public GameObject Explosion;

    public float speed;
    private Transform _Transform;

	// Use this for initialization
	void Start ()
    {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject Bullet1 = (GameObject)Instantiate(Bullet);
            Bullet1.transform.position = BulletPosition.transform.position;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;

        move(direction);      



    }

    private void move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x - 0.225f;

        Vector2 pos = transform.position;
        pos += direction * speed*Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
        

    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if ((colider.tag == "Enemy") || colider.tag == "Enemy Bullet")
        {
            PlayExplosion();
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject _explosion = (GameObject)Instantiate(Explosion);
        _explosion.transform.position = transform.position;
    }
}
