using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameDirector : MonoBehaviour
{
    public GameObject akebip, kakip, starfruitp, nasip, kiuip;//落とすフルーツのプレハブ
    private int asa = 0, ake = 0, kak = 0, sta = 0, nas = 0, kiu = 0;//フルーツを昇格させるときにつかう
    Vector3 asapos = new Vector3(0, 0, 0), akepos = new Vector3(0, 0, 0), kakpos = new Vector3(0, 0, 0), stapos = new Vector3(0, 0, 0), naspos = new Vector3(0, 0, 0);
    //フルーツの生成座標
    private int point = 0;
    GameObject score, result;
    TextMeshProUGUI tmpscore, tmpresult;//テキストを書く
    private bool gameov = true;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("score");
        tmpscore = score.GetComponent<TextMeshProUGUI>();//テキストのオブジェクトを取得
        result = GameObject.Find("result");
        tmpresult = result.GetComponent<TextMeshProUGUI>();//結果のオブジェクトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (asa == 2)//２個同時に消したときに次のランクのフルーツを生成
        {
            Instantiate(akebip).transform.position = asapos / 2;
            asapos = new Vector3(0, 0, 0);
            asa = 0;
            point += 2;
        }
        else if (ake == 2)
        {
            Instantiate(kakip).transform.position = akepos / 2;
            akepos = new Vector3(0, 0, 0);
            ake = 0;
            point += 4;
        }
        else if (kak == 2)
        {
            Instantiate(starfruitp).transform.position = kakpos / 2;
            kakpos = new Vector3(0, 0, 0);
            kak = 0;
            point += 10;
        }
        else if (sta == 2)
        {
            Instantiate(nasip).transform.position = stapos / 2;
            stapos = new Vector3(0, 0, 0);
            sta = 0;
            point += 20;
        }
        else if (nas == 2)
        {
            Instantiate(kiuip).transform.position = naspos / 2;
            naspos = new Vector3(0, 0, 0);
            nas = 0;
            point += 30;
        }
        else if (kiu == 2)
        {
            kiu = 0;
            point += 50;
        }

        if (asa > 2)//3個以上同時に消えたときにフルーツ昇格の変数をリセット
        {
            asapos = new Vector3(0, 0, 0);
            asa = 0;
        }
        else if (ake > 2)
        {
            akepos = new Vector3(0, 0, 0);
            ake = 0;
        }
        else if (kak > 2)
        {
            kakpos = new Vector3(0, 0, 0);
            kak = 0;
        }
        else if (sta > 2)
        {
            stapos = new Vector3(0, 0, 0);
            sta = 0;
        }
        else if (nas > 2)
        {
            naspos = new Vector3(0, 0, 0);
            nas = 0;
        }
        else if (kiu > 2)
        {
            kiu = 0;
        }

        if (gameov)
        {
            tmpscore.text = "" + point;
        }
    }

    public void combi(int fruitnum, Vector3 pos)//消えたフルーツの数だけ呼び出される
    {
        switch (fruitnum)
        {
            case 0:
                asa++;
                asapos += pos;
                break;
            case 1:
                ake++;
                akepos += pos;
                break;
            case 2:
                kak++;
                kakpos += pos;
                break;
            case 3:
                sta++;
                stapos += pos;
                break;
            case 4:
                nas++;
                naspos += pos;
                break;
            case 5:
                kiu++;
                break;
            default:
                break;
        }
    }

    public void gameover()//ゲームオーバーになったら操作をすべて無効にしたい
    {
        tmpresult.text = "Game Over\n" + "" + point;
        gameov = false;
    }
}
