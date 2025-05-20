using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    BoxCollider2D box;
    float delta = 0.0f;//時間を管理
    bool click = false;//クリックを検知
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
        if (Input.GetMouseButtonDown(0))//左クリックしたら
        {
            box.isTrigger = true;//トリガーにする
            click = true;
        }

        if (click)
        {
            delta += Time.deltaTime;
            if (delta > 0.8f)//一定時間たったら
            {
                box.isTrigger = false;//トリガーを切る
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
