using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI life;
    public Image lifeBarFill;
    public GameObject pausePanel;
    public GameObject GameOverPanel;
    public GameObject[] corazones;
    public RectTransform lifeBarRect;
    public float targetValue;
    public float currentValue;
    public float smooth;
    public float minPos;
    public float maxPos;


    public bool inPause;
    private void Update()
    {
        currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * smooth);
        float posX = Mathf.Lerp(minPos, maxPos, currentValue);
        lifeBarRect.localPosition = new Vector3(posX, lifeBarRect.localPosition.y, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inPause = !inPause; // invertir
            if (inPause == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1;
            }
            pausePanel.SetActive(inPause);
        }
    }

    public void UpdateLife(float newValue)
    {
        life.text = "Vida :" + newValue;
    }

    public void UpdateBar(float newValue)
    {
        lifeBarFill.fillAmount = newValue;
    }

    public void UpdateTargetBar(float newValue)
    {
        targetValue = newValue;
    }

    public void Reset()
    {
        Time.timeScale = 1;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void UpdateHearts(int amount)
    {
        if (amount == 0)
        {
            Invoke("ShowGameOver", 2f);
        }
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < amount);
        }
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }

}
