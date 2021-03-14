using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoToLocation : MonoBehaviour
{
    [Header("Player")]
    public GameObject targetLocation;
    public Vector3 target;
    private Vector3 lostTarget;
    Rigidbody rigidbody;
    AnimationController animationController;
    float moveSpeed = 0.4f;
    public BoxCollider bodyCollider;

    [Header("Camera")]
    public GameObject camera;
    public Transform cameraTarget;
    public Vector3 offset;
    public float speed = 0.125f;
    Vector3 lerpLook = new Vector3();

    bool isFinished = false;

    void Awake()
    {
        bodyCollider = GetComponent<BoxCollider>();
        animationController = GetComponent<AnimationController>();
        rigidbody = GetComponent<Rigidbody>();
        target = targetLocation.transform.position;
        lostTarget = target + new Vector3(-50f, 0, 0);
    }

    private void Update()
    {
        if (isFinished)
        {
            if (GameObject.Find("BridgeCreator").GetComponent<BridgeCreater>().isPlaced)
            {
                rigidbody.isKinematic = true;
                bodyCollider.enabled = false;
                Walk(target);
            }
            else if (!GameObject.Find("BridgeCreator").GetComponent<BridgeCreater>().isWon)
            {
                DeepToWater();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log("Değdi");
            isFinished = true;
        }
    }



    private void FixedUpdate()
    {
        if (this.transform.position == targetLocation.transform.position)
        {
            animationController.anim.SetBool("isRunning", false);
            CameraLook();
        }
    }

    public void Walk(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed);
        animationController.anim.SetBool("isRunning", true);
    }

    void DeepToWater()
    {
        Walk(lostTarget);
        rigidbody.isKinematic = false;
        if (this.transform.position == lostTarget)
        {
            moveSpeed = 0f;
        }
    }


    void CameraLook()
    {
        Vector3 position = cameraTarget.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(camera.transform.position, position, speed * 7f* Time.deltaTime);
        camera.transform.position = lerpPosition;

        lerpLook = Vector3.Lerp(cameraTarget.position, lerpPosition, speed * 7f* Time.deltaTime);

        camera.transform.LookAt(lerpLook);
    }


}
