using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    BoxCollider2D box;
    float delta = 0.0f;//���Ԃ��Ǘ�
    bool click = false;//�N���b�N�����m
    GameObject director;
    GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        director = GameObject.Find("GameDirector");
        gameDirector = director.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//���N���b�N������
        {
            box.isTrigger = true;//�g���K�[�ɂ���
            click = true;
        }

        if (click)
        {
            delta += Time.deltaTime;
            if (delta > 0.8f)//��莞�Ԃ�������
            {
                box.isTrigger = false;//�g���K�[��؂�
                delta = 0.0f;
                click = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        gameDirector.gameover();
        box.isTrigger = true;
    }
}
