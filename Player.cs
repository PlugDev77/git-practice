using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower = 5f;

    bool isDelay = false;
    float delayTime = 5.0f;
    float accumTime = 0.0f;

    private bool isHurt = false;
    private int playerHP = 100;
    
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
                // ������ �ִ� ��Ȳ, �����̰� ���� ��Ȳ
                isDelay = true;
                Debug.Log("������ �Ծ 50 ȸ���߽��ϴ�.");
            }
            else
            {
                // ������ ���� ��Ȳ, �����̰� �ִ� ��Ȳ
                //Debug.Log("������ ���� �� �����ϴ� :(");
            }
        }

        // I�� ������ �ʾƵ� �ð������ ��� �ؾ��ϴϱ� ������ ���� ��
        if (isDelay)
        {
            accumTime += Time.deltaTime; // ���� ���� �� �帥 �ð��� ����ؾ��ϴϱ� accumTime�� ������
            if (accumTime >= delayTime) // �帥 �ð��� �����̽ð� ����(5��)�� ���ؼ� 5�ʰ� �������鿡 ���� ó��
            {
                isDelay = false;    // 5�ʰ� �������Ƿ� �����̰� �����ϱ� false
                accumTime = 0.0f;   // 5�ʰ� �������Ƿ� �ٽ� �ʱ�ȭ�ؼ� ���� �����ؾ��ϴϱ� 0.0���� �ٽ� ����
            }
        }
    }

    void EatPotion2()
    {
        if (Input.GetKey(KeyCode.K))
        {
            if (!isDelay)
            {
                // ������ �ִ� ��Ȳ, �����̰� ���� ��Ȳ
                isDelay = true;
                Debug.Log("������ �Ծ 50 ȸ���߽��ϴ�.");

                StartCoroutine(Eat());
            }
            else
            {
                // ������ ���� ��Ȳ, �����̰� �ִ� ��Ȳ
                //Debug.Log("������ ���� �� �����ϴ� :(");
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
            Debug.Log("�̹� ����");
            return;
        }

        if (!isHurt)
        {
            isHurt = true;
            if (playerHP - damage <= 0)
            {
                playerHP = 0;
                Debug.Log("�ֱ�");
            }
            else
            {
                playerHP -= damage;
                Debug.Log(playerHP.ToString() + "/" + "100");
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
        // �̵�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f);
        }
    }

    void jump()
    {
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
