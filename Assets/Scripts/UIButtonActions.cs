using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public GameObject PlayBtn;

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveFrom(PlayBtn, iTween.Hash("y", -500, "time", 2.0f, "easetype", iTween.EaseType.easeOutElastic));//button loading effect
    }

    public void PlayBtnClicked()
    {
        SceneManager.LoadScene("GameScene");
    }


   

}
