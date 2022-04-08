using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{   
    protected Rigidbody rb;

    GameObject sphere;

    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    private float speed = 2f;
    private bool press = false;
    private bool check = false;
    private bool pressStatus = true;
    public float posY = 100;
    public bool win;
    public bool lose;

    [SerializeField] GameObject fury;
    [SerializeField] GameObject breakObject;

    [SerializeField] static int currentLevelIndex;
    [SerializeField] TextMeshProUGUI currentLevelText;

    [SerializeField] Image imageFuryDown;
    [SerializeField] Image imageFuryUp;
    [SerializeField] float FuryTimeDown = 4;
    [SerializeField] float FuryTimeUp = 0;
    [SerializeField] float firstDown = 1;


    private void Start()
    {
            win = false;
            lose = false;
    }
    public enum State
    {
        Idle, Fury, Play, Win, Lose
    }

    [SerializeField] public State _state = State.Idle;
    private void Awake()
    {
        sphere = GameObject.Find("Sphere");
        rb = GetComponent<Rigidbody>();
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    private void FixedUpdate()
    {   
        CheckFury();
        currentLevelText.text = ("LEVEL " + currentLevelIndex.ToString());
        switch (_state)
        {
            case State.Idle:
                Idle();
                if (Input.GetMouseButton(0) && pressStatus) ChangeState(State.Play);
                break;
            case State.Play:
                Play();
                if (FuryTimeUp >= 2) ChangeState(State.Fury);
                if (!Input.GetMouseButton(0) || !pressStatus) ChangeState(State.Idle);
                break;
            case State.Fury:
                Fury();
                if (FuryTimeDown <= 0 || !Input.GetMouseButton(0)) ChangeState(State.Idle);
                break;
            case State.Win:
                Win();
                break;
            case State.Lose:
                Lose();
                break;
                //default:
                //   throw new ArgumentOutOfRangeException();
        }
        // press status
        if (velocity.y == 0) pressStatus = true;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
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
            case State.Idle:
                break;
            case State.Play:
                break;
            case State.Fury:
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
            case State.Idle:
                break;
            case State.Play:
                break;
            case State.Fury:
                break;
            case State.Lose:
                break;
            case State.Win:
                break;
            //default:
            //   throw new ArgumentOutOfRangeException();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_state == State.Play || _state == State.Fury)
        {
            sphere.gameObject.transform.localScale = new Vector3(2f, 2.2f, 2.2f);

        }
        else sphere.gameObject.transform.localScale = new Vector3(2.4f, 2f, 2.2f);

        if (!press)
        {
            velocity.y = 30f;
        }
        else
        {
            if (other.gameObject.tag == "Lastring")
            {
                velocity.y = 30f;
                ChangeState(State.Win);
            }
            else
            {
                if (fury.activeSelf)
                {
                    if (other.gameObject.tag == "Lastring")
                    {
                        velocity.y = 30f;
                        ChangeState(State.Win);
                    }
                    posY = other.transform.position.y;
                    firstDown = 1;
                    press = false;
                }
                else
                {
                    if (other.gameObject.tag == "Unsafe")
                    {
                        if (check)
                        {
                            velocity.y = 30f;
                            firstDown = 1;
                            press = false;
                        }
                        else
                        {
                            velocity.y = 30f;
                            firstDown -= 1;
                            pressStatus = false;
                            press = false;
                            if (firstDown < 0)
                            {
                                ChangeState(State.Lose);
                            }
                        }
                    }
                    else
                    {
                        posY = other.transform.position.y;
                        firstDown = 1;
                        press = false;
                    }
                }
            }
        }
    }

    internal void Idle()
    {
        if (velocity.y < 0)
        {
            velocity.y -= speed;
            sphere.gameObject.transform.localScale = new Vector3(2f, 2.2f, 2.2f);
        }
        if (velocity.y >= 0)
        {
            velocity.y -= speed;
            sphere.gameObject.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
        }
    }
    internal void Play()
    {
        if (pressStatus)
        {
            press = true;
            if (velocity.y >= 0)
            {
                check = true;
                velocity.y = -30f;
            }
            else
            {
                check = false;
                velocity.y = -30f;
            }
        }
    }

    internal void Fury()
    {
        press = true;
        velocity.y = -30f;
    } 

    internal void Win()
    {
        win = true;
        Idle();
        press = false;
        imageFuryUp.enabled = false;
        pressStatus = false;
        PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
    }

    internal void Lose()
    {
        lose = true;
        imageFuryUp.enabled = false;
        Instantiate(breakObject, sphere.transform.position, sphere.transform.rotation);
        gameObject.SetActive(false);
    }

    private void CheckFury()
    {
        if (press)
        {
            if (FuryTimeUp <= 2)
            {
                FuryTimeUp += Time.deltaTime % 60;
            }
        }
        else
        {
            if (imageFuryUp.enabled)
            {
                if (FuryTimeUp > 0 && _state == State.Idle)
                {
                    FuryTimeUp -= Time.deltaTime % 60;
                }
            }
            else FuryTimeUp = 0;
        }
        imageFuryUp.fillAmount = FuryTimeUp / 2;
        if (FuryTimeUp > 0 && FuryTimeUp <= 2 && imageFuryDown.enabled == false)
        {
            imageFuryUp.enabled = true;
        }
        else imageFuryUp.enabled = false;
        //
        if (imageFuryDown.enabled)
        {
            FuryTimeDown -= Time.deltaTime % 60;
        }
        else FuryTimeDown = 4;
        imageFuryDown.fillAmount = FuryTimeDown / 4;
        if (fury.activeSelf)
        {
            imageFuryDown.enabled = true;
        }
        else imageFuryDown.enabled = false;

        if (FuryTimeUp >= 2)
            fury.SetActive(true);
        if (FuryTimeDown <= 0)
            fury.SetActive(false);
    }
}
