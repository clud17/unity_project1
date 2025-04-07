using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public int duckIndex;
    public GameObject managerObject;

    private GameManager gameManager;

    void Awake()
    {
        managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Duck otherDuck = other.gameObject.GetComponent<Duck>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        // 범위 내에 collider를 지니고 있는 오브젝트의 콜라이더를 모두 담는 배열

        if (otherDuck != null)
        {
            if ((duckIndex == otherDuck.duckIndex) && duckIndex < gameManager.duckPrefabs.Length)
            {
                gameManager.collisionCount++;
                Vector2 collisionPoint = other.contacts[0].point;
                gameManager.mergeDuck(duckIndex, collisionPoint);

                foreach (Collider2D hit in colliders) // 범위 내 모든 오브젝트에 대해
                {
                    Rigidbody2D rigidbody = hit.GetComponent<Rigidbody2D>();

                    if (rigidbody != null)
                    {
                        Vector2 direction = rigidbody.transform.position - transform.position;
                        rigidbody.AddForce(direction.normalized * 2f, ForceMode2D.Impulse);
                        // 밀어낼 방향을 구하고, 그 방향으로 오브젝트에게 힘을 부여
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}
