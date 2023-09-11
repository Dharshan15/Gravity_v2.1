using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject top;
    public GameObject middle;
    public GameObject bottom;
    public GameObject coin;
    public GameObject gun;

    private PlayerController player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
        
    public int score = 0;
    public int time = 0;
    public float[] coinYPos = { 1.4f, -1.5f };
    public float[] gunYPos = { 1.4f, -1.5f };

    public void Start()
    {
            player = FindObjectOfType<PlayerController>();

            Time.timeScale = 1;
            scoreText.gameObject.SetActive(true);
            coinsText.gameObject.SetActive(true);
            StartCoroutine(SpawnBottom());
            StartCoroutine(SpawnTop());
            StartCoroutine(SpawnMiddle());
            StartCoroutine(Coins());
            StartCoroutine(Timer());
            StartCoroutine(Gun());

    }
    private void Update()
    {
        scoreText.text = "SCORE : " + score;
        coinsText.text = "COINS : " + player.coins ;
    }
    IEnumerator SpawnBottom()
    {
        while (true)
        {
            float waitTime = Random.Range(3f, 7f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(bottom, bottom.transform.position, bottom.transform.rotation);
        }


    }
    IEnumerator SpawnTop()
    {
        while (true)
        {
            float waitTime = Random.Range(4f, 9f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(top, top.transform.position, top.transform.rotation);
        }

    }
    IEnumerator SpawnMiddle()
    {
        while (true)
        {
            float waitTime = Random.Range(5f, 10f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(middle, middle.transform.position, middle.transform.rotation);
        }

    }

    IEnumerator Coins()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, 2);
            float randomCoinY = coinYPos[randomIndex];
            float waitTime = Random.Range(4f, 6f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(coin, new Vector2(middle.transform.position.x, randomCoinY), middle.transform.rotation);
            
        }
    }
    IEnumerator Gun()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, 2);
            float randomGunY = gunYPos[randomIndex];
            float waitTime = Random.Range(7f, 10f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(gun, new Vector2(middle.transform.position.x, randomGunY), middle.transform.rotation);

        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }
    }
    void TimeCount()
    {
        score += 1;
        time += 1;
    }
}
