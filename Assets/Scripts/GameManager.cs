using System.Collections;
using System.Collections.Generic;
using TMPro;                            // TextMeshPro ����� ���� ��������
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int collisionCount;
    public GameObject[] duckPrefabs;
    public int gameScore;
    public TextMeshProUGUI scoreText;     // ���� �ݿ��� ���� �ؽ�Ʈ UI(Score Value)
    public GameObject nextSprite;         // ������ ���� ǥ�õ� ���� ������ ��������Ʈ
    public GameObject presentSprite;      // �ȴ��̰� ��� ���� ���� ������ ��������Ʈ
    public Sprite[] duckSprites;          // ���� ��������Ʈ�� ���� ��
    public AudioClip mergeSound;          // ȿ������ ���� ����


    public static bool canPlay = true;

    void Start()
    {
        gameScore = 0;
        canPlay = true;
        string format = gameScore.ToString("D4");  // ������ ǥ�⸦ 0000 �������� �ϱ� ���� ����
        scoreText.text = format;  // ������ ����
    }

    public void mergeDuck(int duckIndex, Vector2 pos)
    {
        if (collisionCount >= 2 && duckIndex < duckPrefabs.Length)
        {
            if (duckIndex < duckPrefabs.Length - 1)
            {
                Instantiate(duckPrefabs[duckIndex + 1], pos, Quaternion.identity);
            }

            switch (duckIndex)
            {
                case 0:
                    gameScore += 1;
                    break;
                case 1:
                    gameScore += 3;
                    break;
                case 2:
                    gameScore += 6;
                    break;
                case 3:
                    gameScore += 10;
                    break;
                case 4:
                    gameScore += 15;
                    break;
                case 5:
                    gameScore += 21;
                    break;
                case 6:
                    gameScore += 28;
                    break;
                case 7:
                    gameScore += 36;
                    break;
                case 8:
                    gameScore += 45;
                    break;
                case 9:
                    gameScore += 55;
                    break;
                case 10:
                    gameScore += 66;
                    break;
            }
            
            GetComponent<AudioSource>().PlayOneShot(mergeSound); // ������ �� ȿ���� ���

            string format = gameScore.ToString("D4");
            scoreText.text = format;   // ���� ����

            collisionCount = 0;
        }
    }

    public void SetPresentInfo(int duckIndex)
    {
        switch (duckIndex) // ���� ������ �ε����� ���� �ȴ��̰� ��� ���� ��������Ʈ ����
        {
            case 0:
                presentSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[0];
                presentSprite.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                break;
            case 1:
                presentSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[1];
                presentSprite.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                break;
            case 2:
                presentSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[2];
                presentSprite.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                break;
            case 3:
                presentSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[3];
                presentSprite.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
    }

    public void SetInfo(int duckIndex)
    {
        switch (duckIndex) // ���� ������ �ε����� ���� ������ ���� ǥ�õ� ��������Ʈ ����
        {
            case 0:
                nextSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[0];
                break;
            case 1:
                nextSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[1];
                break;
            case 2:
                nextSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[2];
                break;
            case 3:
                nextSprite.GetComponent<SpriteRenderer>().sprite = duckSprites[3];
                break;
        }
    }

    public IEnumerator GameOver()
    {
        canPlay = false;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}