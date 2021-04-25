using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectUp : MonoBehaviour
{
    public float levelMoveSpeed = 3.5f;

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        float step = levelMoveSpeed * Time.deltaTime; // calculate distance to move
        transform.Translate(Vector3.up * Time.deltaTime * levelMoveSpeed);
    }
}
