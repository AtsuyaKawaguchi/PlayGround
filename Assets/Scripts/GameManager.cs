using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text m_scoreText = default;
    [SerializeField] Text m_hpText = default;
    //int score = 0;
    [SerializeField] int hp = 3;
    [SerializeField] int clearScore = 3;
    static int[] array = new int[] { 0, 1, 2 };
    static int m_SceneIndex = default;
    
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    /*public void AddScore(int score)//score加算方式、無限にスコアを競う場合に使う
    {
        this.score += score;
        Debug.Log(this.score);
        m_scoreText.text = "SCORE: " + this.score.ToString("D5");
        
        if (this.score == clearScore)
        {
            SceneManager.LoadScene("ClearScene");
        }

    }*/

    public void LoseScore(int score)
    {
        clearScore -= score;
        Debug.Log(clearScore);
        m_scoreText.text =  clearScore.ToString("D2");
        m_scoreText.color = Color.white;
       

        if (clearScore == 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
       
    public void LoseHp(int hp)
    {
        this.hp -= hp;
        Debug.Log(this.hp);
        m_hpText.text = this.hp.ToString("D2");
        
        
        
        if(this.hp == 2)
        {
            m_hpText.color = Color.yellow;
        }
        else if (hp == 1)
        {
            m_hpText.color = Color.red;
        }
        
        if (this.hp == 0)
        {
            Debug.Log("死んだ");
            //Finish();
            RandomSceneChange();
            //GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.red;  赤色に変える
        }
       
    }

    public static void RandomSceneChange()
    {
        int scenes = array[m_SceneIndex % array.Length];
        m_SceneIndex++;
        SceneManager.LoadScene(scenes);
    }

    public void Finish()
    {
        Invoke("RandomSceneChange", 3f);
    }

}
