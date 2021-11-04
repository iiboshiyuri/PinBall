using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //得点を表示するテキスト
    private GameObject scoree;
    //scoreの変数?
    int score = 0;
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //scoreeに得点を表示
        this.scoree.GetComponent<Text>().text = this.score;
        //条件分けて関数scoreに得点つける！
        if (tag == "SmallStarTag")
        {
            score = score + 5;

        }
        else if (tag == "LargeCloudTag")
        {
            score = score + 20;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeStarTag")
        {
            score = score + 10;
        }
        
    }
}