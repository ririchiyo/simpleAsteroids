using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quitButton : MonoBehaviour
{
    public Button _button;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = _button.GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
