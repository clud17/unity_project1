using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D other)  // 오리가 충돌하면 게임오버
    {
        if (other.transform.tag == "Duck")
        {
            StartCoroutine(gameManager.GameOver());
        }
    }
}