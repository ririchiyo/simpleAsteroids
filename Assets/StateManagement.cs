using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagement : MonoBehaviour
{
    public GameObject _player;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(!_player.activeInHierarchy);
        }
    }
}
