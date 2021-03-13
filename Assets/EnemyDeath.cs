using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Enemy enemy;
    EnemyAnimatorController animatorController;
    bool isAnimationPlaying = false;
    float timer = 0f;



    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && enemy.IsFoe)
        {

            gameObject.transform.position = new Vector2(transform.position.x, 50f);
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

            if (gameObject.transform.position.y >= 50f)
            {
                Destroy(gameObject);
            }

            Debug.Log("Player'a değdim");
        }

    }
}
