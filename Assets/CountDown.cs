using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CountDownTimeText;
    [SerializeField] Image image;
    [SerializeField] float CountDownTime;

        private void Update()
    {
    }
    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        if(CountDownTime != 0)
        {
            CountDownTime -= Time.deltaTime % 60;
            CountDownTimeText.text = ((int)CountDownTime).ToString();
        }
        image.fillAmount = CountDownTime / 5;
        PlayerPrefs.SetFloat("CountDownTime", CountDownTime);
    }
}
