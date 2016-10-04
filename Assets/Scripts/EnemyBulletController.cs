using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool directionSet;

    void Awake()
    {
        speed = 5f;
        directionSet = false;
    }
    
    // Use this for initialization
    void Start ()
    {
        

    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        directionSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (directionSet)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x)||(transform.position.y < min.y)||(transform.position.y > max.y))
            {
                Destroy(gameObject);
            }

        }
        

    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }




}
