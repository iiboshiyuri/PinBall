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
    private GameObject scoree;
    //Scoreの変数?
    int Score = 0;
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoree = GameObject.Find("scoree");
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
        Debug.Log(other.gameObject.tag);
        //条件分けて関数scoreに得点つける！
        if (other.gameObject.tag == "SmallStarTag")
        {
            Score = Score + 5;

        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            Score = Score + 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeStarTag")
        {
            Score = Score + 10;
        }
        //scoreeに得点を表示
        this.scoree.GetComponent<Text>().text = this.Score + "point";//10は仮
    }
}