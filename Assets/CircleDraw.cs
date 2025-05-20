using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDraw : MonoBehaviour
{
    PolygonCollider2D polygon;
    public int n=12;
    public float r = 1.0f;//頂点数と半径をインスペクターからもいじれるように
    Vector2[] vector2;//頂点の座標の集合

    // Start is called before the first frame update
    void Start()
    {
        polygon= GetComponent<PolygonCollider2D>();
        vector2 = new Vector2[n];//ｎ個の要素を持つ配列を宣言
        for (int i = 0; i < n; i++)
        {
            vector2[i] = new Vector2(r * Mathf.Cos(i * 2 * Mathf.PI / n), r * Mathf.Sin(i * 2 * Mathf.PI / n));//半径rの円周上に等間隔に頂点を配置
        }
        polygon.SetPath(0, vector2);//pathsのelementsのn番目に設定した頂点集合を描く
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        polygon.isTrigger = false;
    }
}
