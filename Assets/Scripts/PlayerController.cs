using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
    {

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
	
	}

    private void move()
    {
        
    }
}
