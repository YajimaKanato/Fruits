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
        rigid2d.isKinematic = true;//重力をなくす
        player = GameObject.Find("Player");//プレイヤーオブジェクトを取得
        director = GameObject.Find("GameDirector");//ディレクターオブジェクトを取得
        gameDirector = director.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || this.transform.position.y < 3)
        {
            rigid2d.isKinematic = false;//重力を付与
            mouseclick = true;//クリックを検知
        }

        if (!mouseclick)
        {
            this.transform.position = player.transform.position;//クリックされるまではプレイヤーオブジェクトに追従
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
