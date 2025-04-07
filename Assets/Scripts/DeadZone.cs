using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D other)  // ������ �浹�ϸ� ���ӿ���
    {
        if (other.transform.tag == "Duck")
        {
            StartCoroutine(gameManager.GameOver());
        }
    }
}