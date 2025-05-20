using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject asaip, akebip, kakip;//落とすフルーツのプレハブ
    GameObject fruit;//生成するフルーツのプレハブを受け取るオブジェクト
    int rand;//生成するフルーツのランダム化するための変数
    float clickdelta = 0.0f;//クリックを押してから次のオブジェクトが生成されるまでの時間
    bool mouseclick = false;//クリックしたかどうか

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 100);
        inst(rand).transform.position = this.transform.position;//生成したフルーツの座標を設定
        Application.targetFrameRate = 60;//フレームレートを60に固定
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseclick = true;//左クリックが押されたことを感知
        }

        if (mouseclick)//左クリックが押されたら新しくフルーツを生成
        {
            clickdelta += Time.deltaTime;
            if (clickdelta > 0.8f)//一定時間たったら
            {
                rand = Random.Range(0, 100);
                inst(rand).transform.position = this.transform.position;
                clickdelta = 0.0f;
                mouseclick = false;
                //クリック前の状態に戻す
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))//矢印キーの操作
        {
            transform.position += new Vector3(-0.05f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.05f, 0, 0);
        }


        if (transform.position.x > 3.0f)//画面外に出たら反対側に出てくる
        {
            transform.position = new Vector3(-3.0f, 4.0f, 0);
        }
        if (transform.position.x < -3.0f)
        {
            transform.position = new Vector3(3.0f, 4.0f, 0);
        }
    }

    GameObject inst(int rand)//ランダムでフルーツを生成するメソッド
    {
        if (rand < 50)//数字を変化させることで確率を操作する
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
