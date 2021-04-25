using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnCircle : MonoBehaviour
{
    public GameObject ball;
    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            GameObject.Instantiate(ball);
            Vector3 newPosition = ball.transform.position;
            newPosition.x = 0 + Random.Range(-3f, 3f);
            ball.transform.position = newPosition;
        }
    }
}
