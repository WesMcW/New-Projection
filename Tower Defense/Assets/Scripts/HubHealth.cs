using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubHealth : MonoBehaviour
{
    public int hubHp;
    public GameObject loseScreen;

    private void Update()
    {
        if (hubHp <= 0)
        {
            Lose();
            EnemySpawner.inst.canSpawn = false;
        }
    }

    public void Lose()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        loseScreen.SetActive(true);
    }
}
