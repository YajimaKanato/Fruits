using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nasiController : MonoBehaviour
{
    GameObject director;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");//ディレクターオブジェクトを取得
        gameDirector = director.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            gameDirector.combi(4, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
