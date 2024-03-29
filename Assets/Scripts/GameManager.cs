﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static float slowness = 10f;
    public GameObject RestartButton;

    public void EndGame()
    {
        StartCoroutine(ShowRestart());
    }
    IEnumerator ShowRestart()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; 
        yield return new WaitForSeconds(1f/slowness);
        Time.timeScale = 0f;
        RestartButton.SetActive(true);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
