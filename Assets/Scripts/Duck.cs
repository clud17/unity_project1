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
        // ���� ���� collider�� ���ϰ� �ִ� ������Ʈ�� �ݶ��̴��� ��� ��� �迭

        if (otherDuck != null)
        {
            if ((duckIndex == otherDuck.duckIndex) && duckIndex < gameManager.duckPrefabs.Length)
            {
                gameManager.collisionCount++;
                Vector2 collisionPoint = other.contacts[0].point;
                gameManager.mergeDuck(duckIndex, collisionPoint);

                foreach (Collider2D hit in colliders) // ���� �� ��� ������Ʈ�� ����
                {
                    Rigidbody2D rigidbody = hit.GetComponent<Rigidbody2D>();

                    if (rigidbody != null)
                    {
                        Vector2 direction = rigidbody.transform.position - transform.position;
                        rigidbody.AddForce(direction.normalized * 2f, ForceMode2D.Impulse);
                        // �о ������ ���ϰ�, �� �������� ������Ʈ���� ���� �ο�
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}
