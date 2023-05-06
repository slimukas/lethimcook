using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ReadyPlayers : MonoBehaviour
{
    [SerializeField] private Image pcReadyImage;
    [SerializeField] private Image vrReadyImage;
    [SerializeField] private int countdown;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject readyPannel;
    private bool vrReady;
    private bool pcReady;

    public bool canUnready = true;

    public bool isPcReady = false;
    public bool isVrReady = false;
    public int scene;

    private void Update()
    {
        if (canUnready == false)
            return;

        if (isPcReady == true && isVrReady == true)
        {
            canUnready = false;
            StartCoroutine(LoadScene());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PcClicked();
        }
    }

    public void VrClicked()
    {
        if (canUnready == true)
        {
            isVrReady = !isVrReady;
            if (isVrReady == true)
            {
                vrReadyImage.color = Color.green;
            }
            else
            {
                vrReadyImage.color = Color.grey;
            }
        }

    }

    private void PcClicked()
    {
        if (canUnready == true)
        {
            isPcReady = !isPcReady;
            if (isPcReady == true)
            {
                pcReadyImage.color = Color.green;
            }
            else
            {
                pcReadyImage.color = Color.grey;
            }
        }

    }

    IEnumerator LoadScene()
    {
        readyPannel.SetActive(false);
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        countdownText.text = countdown.ToString();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
    }
}
