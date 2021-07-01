using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange＿CtoO : MonoBehaviour
{
    AudioSource m_audio = default;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Invoke("NextSceneChange",1f);
            m_audio.Play();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Invoke("TitleSceneChange",1f);
            m_audio.Play();
        }

    }
    void NextSceneChange()
    {
        SceneManager.LoadScene(8);
    }

    void TitleSceneChange()
    {
        SceneManager.LoadScene(3);
    }
}
