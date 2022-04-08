using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GamePlayController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject nextLevelUI;

    PlayerController PlayerControllerScript;

    [SerializeField] TextMeshProUGUI CountDownTimeText;
    [SerializeField] Image image;
    [SerializeField] float CountDownTime = 5;

    private enum State
    {
        Init, Play, Win, Lose
    }
    private State _state = State.Init;

    void Start()
    {
        PlayerControllerScript = player.GetComponent<PlayerController>();
    }

    private void Update()
    {   
        if (PlayerControllerScript.win)
        {
            ChangeState(State.Win);
        }
        if (PlayerControllerScript.lose)
        {
            ChangeState(State.Lose);
        }
        switch (_state)
        {
            case State.Init:
                if (Input.GetMouseButton(0)) ChangeState(State.Play);
                break;
            case State.Play:
                break;
            case State.Win:
                {
                    nextLevelUI.SetActive(true);
                    LoadScene();
                }
                break;
            case State.Lose:
                {
                    gameOverUI.SetActive(true);
                    LoadScene();
                }

                break;
                //default:
                //   throw new ArgumentOutOfRangeException();
        }
        // countdown
        if (CountDownTime != 0)
        {
            CountDownTime -= Time.deltaTime % 60;
            CountDownTimeText.text = ((int)CountDownTime).ToString();
        }
        image.fillAmount = CountDownTime / 5;
    }

    private void ChangeState(State newState)
    {
        if (newState == _state) return;
        ExitCurrentState();
        _state = newState;
        EnterNewState();
    }

    private void ExitCurrentState()
    {
        switch (_state)
        {
            case State.Init:
                break;
            case State.Play:
                break;
            case State.Lose:
                break;
            case State.Win:
                break;
                //default:
                //    throw new ArgumentOutOfRangeException();
        }
    }

    private void EnterNewState()
    {
        switch (_state)
        {
            case State.Init:
                break;
            case State.Play:
                break;
            case State.Lose:
                break;
            case State.Win:
                break;
                //default:
                //   throw new ArgumentOutOfRangeException();
        }
    }

    internal void LoadScene()
    {
        StartCoroutine(DelaySceneLoad());
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BtnRetry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BtnTaptonext()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
