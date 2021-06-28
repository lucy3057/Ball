using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 10;
    //float moveSpeed;

    public GameManagerLogic manager;
    public GameObject Panel;

    public Text ScoreText;
    public Text CountText;
    public Text EndText;

    public int itemCount;
    int jumpCount;
    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        rigid.drag = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            jumpCount++;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
        if (jumpCount >= 2)
        {
            isJump = true;
            jumpCount = 0;
        }
        if (this.gameObject.transform.position.y < -10)
        {
            SceneManager.LoadScene(manager.stage);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor" || collision.gameObject.name == "YProp" || collision.gameObject.name == "Prop")
        {
            {
                isJump = false;
                jumpCount = 0;
            }
        }
        else if (collision.gameObject.name == "SlowFloor")
        {
            isJump = false;
            jumpCount = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemCount++;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Goal"))
        {
            Panel.SetActive(true);
            CountText.text = "Eaten Coin : " + itemCount;
            Time.timeScale = 0;


            if (itemCount == 20)
            {
                ScoreText.text = "Perfect !";
            }
            else if (itemCount < 20 && itemCount > 15)
            {
                ScoreText.text = "Good";
            }
            else if (itemCount <= 15 && itemCount >= 10)
            {
                ScoreText.text = "Soso";
            }
            else if (itemCount <= 9 && itemCount >= 1)
            {
                ScoreText.text = "Bad";
            }
            else if(itemCount == 0)
            {
                ScoreText.text = "Worst";
            }
            else if(manager.stage == 2)
            {
                EndText.text = "Continue";
            }
        }
    }
    public void ButtonClick()
    {
        if (manager.stage == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(manager.stage + 1);
        }
        Time.timeScale = 1;
    }
}