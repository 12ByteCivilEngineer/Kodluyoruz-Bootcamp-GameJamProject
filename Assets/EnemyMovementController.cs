using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    GameObject player;
    Vector3 targetVector;
    [SerializeField] float fieldOfViewDistance = 30f;
    Rigidbody _rigidbody;
    [Space] [SerializeField] float speed=5f;
    bool isFollowing = false;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        targetVector = player.transform.position - transform.position;
        if (targetVector.magnitude <= fieldOfViewDistance && !isFollowing)
        {
            isFollowing = true;
        }
        if (isFollowing)
        {
            _rigidbody.velocity = targetVector.normalized * speed;
            Vector3 lookTarget = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(lookTarget);
        }
    }
}
