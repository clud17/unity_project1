using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDuck : MonoBehaviour
{
    public GameObject[] duckPrefabs;
    public GameObject managerObject;
    public GameManager gameManager;
    public int spawnNum;
    public int spawnNum2;
    public AudioClip spawnSound;    // 소환할 때 재생될 효과음을 담을 변수
    public float clickCooldown = 0.3f;
    private float lastClickTime;

    void Awake()
    {
        gameManager = managerObject.GetComponent<GameManager>();
        spawnNum = Random.Range(0, 3);
        spawnNum2 = Random.Range(0, 3);

        gameManager.SetPresentInfo(spawnNum);
        gameManager.SetInfo(spawnNum2);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.canPlay)
        {
            Vector2 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && (hit.transform.tag == "ClickArea" || hit.transform.tag == "Duck") && Time.time - lastClickTime > clickCooldown)
            {
                float xPos = hit.point.x;
                Vector2 spawnPosition = new Vector2(xPos, 3.5f);
                Instantiate(duckPrefabs[spawnNum], spawnPosition, Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(spawnSound);  // 소환할 때 효과음 재생

                spawnNum = spawnNum2;
                spawnNum2 = Random.Range(0, 3);

                gameManager.SetPresentInfo(spawnNum);
                gameManager.SetInfo(spawnNum2);

                lastClickTime = Time.time;
            }
        }
    }
}