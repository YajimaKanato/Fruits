using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDraw : MonoBehaviour
{
    PolygonCollider2D polygon;
    public int n=12;
    public float r = 1.0f;//���_���Ɣ��a���C���X�y�N�^�[������������悤��
    Vector2[] vector2;//���_�̍��W�̏W��

    // Start is called before the first frame update
    void Start()
    {
        polygon= GetComponent<PolygonCollider2D>();
        vector2 = new Vector2[n];//���̗v�f�����z���錾
        for (int i = 0; i < n; i++)
        {
            vector2[i] = new Vector2(r * Mathf.Cos(i * 2 * Mathf.PI / n), r * Mathf.Sin(i * 2 * Mathf.PI / n));//���ar�̉~����ɓ��Ԋu�ɒ��_��z�u
        }
        polygon.SetPath(0, vector2);//paths��elements��n�Ԗڂɐݒ肵�����_�W����`��
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
