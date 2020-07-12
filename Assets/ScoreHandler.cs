using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    private TextMeshProUGUI thisText;
    private static int _score;
    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = _score.ToString();
    }

    public static void AddScore(int score)
    {
        _score += score;
    }
}
