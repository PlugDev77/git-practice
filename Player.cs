using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower = 5f;

    bool isDelay = false;
    float delayTime = 3.0f; // 수정
    float accumTime = 0.0f;

    private bool isHurt = false;
    private int playerHP = 200; // 수정
    
    void Start()
    {
        
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
        jump();
        EatPotion2();
    }

    void EatPotion()
    {
        if (Input.GetKey(KeyCode.I))
        {
            if (!isDelay)
            {
                // 먹을수 있는 상황, 딜레이가 없는 상황
                isDelay = true;
                Debug.Log("포션을 먹어서 50 회복했습니다.");
            }
            else
            {
                Debug.Log("12345");
                Debug.Log("피곤해요...집에가고싶어요... 졸려요");
                Debug.Log("피곤해요...집에가고싶어요... 졸려요");
                Debug.Log("포션을 먹어서 50 회복했습니다.");
                Debug.Log("포션을 먹어서 50 회복했습니다.");
                // 먹을수 없는 상황, 딜레이가 있는 상황
                //Debug.Log("포션을 먹을 수 없습니다 :(");
            }
        }

     
    }

    void EatPotion2()
    {
        if (Input.GetKey(KeyCode.K))
        {
            if (!isDelay)
            {
                // 먹을수 있는 상황, 딜레이가 없는 상황
                isDelay = true;
                Debug.Log("포션을 먹어서 50 회복했습니다.");

                StartCoroutine(Eat());
            }
            else
            {
                // 먹을수 없는 상황, 딜레이가 있는 상황
                //Debug.Log("포션을 먹을 수 없습니다 :(");
            }
        }

        IEnumerator Eat()
        {
            yield return new WaitForSeconds(5f);
            isDelay = false;
        }
    }

    public void hurt(int damage)
    {
        if (playerHP <= 0) {
            Debug.Log(playerHP.ToString() + "/" + "100");
            Debug.Log("아직 안죽었을수도");
            return;
        }

        if (!isHurt)
        {
            isHurt = true;
            if (playerHP - damage <= 0)
            {
                playerHP = 0;
                Debug.Log("주금 사실 안주금 ㅋㅋ");
                Debug.Log("진짜 죽었다니까? ㅋㅋ");
                Debug.Log("주");
            }
            else
            {
                playerHP -= damage;
                Debug.Log(playerHP.ToString() + "/" + "너무 졸리당...");
                Debug.Log(playerHP.ToString() + "/" + "너무졸령");
                StartCoroutine(HurtDelay());
            }
        }

        IEnumerator HurtDelay()
        {
            yield return new WaitForSeconds(1.5f);
            isHurt = false;
        }
    }

    void move()
    {
        // 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
    }

    void jump()
    {
        // 점프
        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Monster"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.SetActive(false);
        */
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collsion.gameObject.name + " stay");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collsion.gameObject.name + " exit");
    }
}
