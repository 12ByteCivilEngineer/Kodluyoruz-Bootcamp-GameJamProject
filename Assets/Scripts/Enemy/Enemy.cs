using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyMovementController enemyMovementController;
    [SerializeField] GameObject turnFriendlyVFX;
    bool isFoe = true;
    private void Awake()
    {
        enemyMovementController = GetComponent<EnemyMovementController>();
    }
    public void TurnFriendly()
    {
        Instantiate(turnFriendlyVFX, transform.position, Quaternion.identity);
        isFoe = false;
        GameManager.ObjectToFollow.Add(gameObject);
        enemyMovementController.FollowIndex = GameManager.ObjectToFollow.Count - 2;
        enemyMovementController.Foe = false;
    }
}
