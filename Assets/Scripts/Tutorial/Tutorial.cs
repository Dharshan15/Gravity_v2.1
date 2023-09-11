using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI startText;
    Rigidbody2D rigidBody;

    public GameObject bullet;
    public GameObject enemy;
    public bool isTop = false;
    public bool isGameOver = false;

    private float halfScreenWidth; // Store the screen width here
    private bool rightTextDisplayed = false; // Flag to check if the right text has been displayed

    private float timeSinceLastShot = 1f;
    private float shootingCooldown = 1f;
    private Vector2 touchStartPos;

    private bool isSwipedUp = false;
    private bool isSwipedDown = false;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        halfScreenWidth = Screen.width / 2; // Store the screen width during Start
    }

    void Update()
    {
        // Check for touch input 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isGameOver && touch.position.x < halfScreenWidth)
            {
                touchStartPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended && !isGameOver && touch.position.x < halfScreenWidth)
            {
                Vector2 touchEndPos = touch.position;
                Vector2 swipeDirection = touchEndPos - touchStartPos;

                // Check if swipe direction is upwards
                if (swipeDirection.y > 0)
                {
                    rigidBody.gravityScale = -2.2f;
                    isTop = true;
                    isSwipedUp = true;
                }
                else
                {
                    rigidBody.gravityScale = 2.2f;
                    isTop = false;
                    isSwipedDown = true;
                }
            }
            if (isSwipedDown && isSwipedUp && !rightTextDisplayed)
            {
                leftText.gameObject.SetActive(false);
                enemy.gameObject.SetActive(true);
                rightText.gameObject.SetActive(true);
                rightTextDisplayed = true;
                
            }
            else if (touch.position.x > halfScreenWidth && touch.phase == TouchPhase.Began && rightTextDisplayed)
            {
                // Check if enough time has passed since the last shot
                if (timeSinceLastShot >= shootingCooldown)
                {
                    Instantiate(bullet, new Vector2(bullet.transform.position.x, transform.position.y), bullet.transform.rotation);
                    timeSinceLastShot = 0f; // Reset the time for the next shot
                    rightText.gameObject.SetActive(false);
                    startText.gameObject.SetActive(true);
                    StartCoroutine(WaitAndLoadScene());
                }
            }
        }

        if (gameObject.transform.position.x > 11)
            gameObject.transform.position = new Vector2(-6.32f, -3.28f);

        if (isTop)
            transform.eulerAngles = new Vector3(0, 180, 180);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);

    }

    IEnumerator WaitAndLoadScene()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        
        SceneManager.LoadScene(2);
    }
}
