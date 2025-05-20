using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject asaip, akebip, kakip;//���Ƃ��t���[�c�̃v���n�u
    GameObject fruit;//��������t���[�c�̃v���n�u���󂯎��I�u�W�F�N�g
    int rand;//��������t���[�c�̃����_�������邽�߂̕ϐ�
    float clickdelta = 0.0f;//�N���b�N�������Ă��玟�̃I�u�W�F�N�g�����������܂ł̎���
    bool mouseclick = false;//�N���b�N�������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 100);
        inst(rand).transform.position = this.transform.position;//���������t���[�c�̍��W��ݒ�
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɌŒ�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseclick = true;//���N���b�N�������ꂽ���Ƃ����m
        }

        if (mouseclick)//���N���b�N�������ꂽ��V�����t���[�c�𐶐�
        {
            clickdelta += Time.deltaTime;
            if (clickdelta > 0.8f)//��莞�Ԃ�������
            {
                rand = Random.Range(0, 100);
                inst(rand).transform.position = this.transform.position;
                clickdelta = 0.0f;
                mouseclick = false;
                //�N���b�N�O�̏�Ԃɖ߂�
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))//���L�[�̑���
        {
            transform.position += new Vector3(-0.05f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.05f, 0, 0);
        }


        if (transform.position.x > 3.0f)//��ʊO�ɏo���甽�Α��ɏo�Ă���
        {
            transform.position = new Vector3(-3.0f, 4.0f, 0);
        }
        if (transform.position.x < -3.0f)
        {
            transform.position = new Vector3(3.0f, 4.0f, 0);
        }
    }

    GameObject inst(int rand)//�����_���Ńt���[�c�𐶐����郁�\�b�h
    {
        if (rand < 50)//������ω������邱�ƂŊm���𑀍삷��
        {
            fruit = Instantiate(asaip);
        }
        else if (rand < 80)
        {
            fruit = Instantiate(akebip);
        }
        else if (rand < 100)
        {
            fruit = Instantiate(kakip);
        }
        return fruit;
    }
}
