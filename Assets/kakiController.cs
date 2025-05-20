using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakiController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    bool mouseclick = false;
    GameObject player, director;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.isKinematic = true;//�d�͂��Ȃ���
        player = GameObject.Find("Player");//�v���C���[�I�u�W�F�N�g���擾
        director = GameObject.Find("GameDirector");//�f�B���N�^�[�I�u�W�F�N�g���擾
        gameDirector = director.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || this.transform.position.y < 3)
        {
            rigid2d.isKinematic = false;//�d�͂�t�^
            mouseclick = true;//�N���b�N�����m
        }

        if (!mouseclick)
        {
            this.transform.position = player.transform.position;//�N���b�N�����܂ł̓v���C���[�I�u�W�F�N�g�ɒǏ]
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            gameDirector.combi(2, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
