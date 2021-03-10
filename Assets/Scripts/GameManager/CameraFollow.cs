using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;
    public Vector3 offset;
    Vector3 lerpPositionTarget = new Vector3();
    

    

    private void LateUpdate()
    {
        Vector3 position = target.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, position, speed * 10f * Time.deltaTime);
        transform.position = lerpPosition;

        lerpPositionTarget = Vector3.Lerp(lerpPositionTarget, target.transform.position, speed * 10f * Time.deltaTime);
        
        transform.LookAt(lerpPositionTarget);

        if (Game.isGameOver || !Game.isGameRunning)
        {
            speed = 0f;
        }
    }
}
