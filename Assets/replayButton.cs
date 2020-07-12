using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class replayButton : MonoBehaviour
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
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
