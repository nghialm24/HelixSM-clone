using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Funzilla
{
	internal class Gameplay : MonoBehaviour
	{
		private enum State
		{
			Init,
			Play,
			Win,
			Lose
		}

		private State _state = State.Init;

		internal static Gameplay Instance;
		private void Init()
		{
			// TODO: Init game here
			
			// Hide splash screen after game is initialized
			SceneManager.Instance.HideLoading();
			SceneManager.Instance.HideSplash();
		}

		internal void Play()
		{
			ChangeState(State.Play);
		}

		internal void Win()
		{
			ChangeState(State.Win);
		}

		internal void Lose()
		{
			ChangeState(State.Lose);
		}

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{

		}

		private void EnterNewState()
		{
			switch (_state)
			{
				case State.Init:
					break;
				case State.Play:
					break;
				case State.Win:
					break;
				case State.Lose:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		private void ChangeState(State newState)
		{
			if (newState == _state) return;
			ExitOldState();
			_state = newState;
			EnterNewState();
		}
		private void ExitOldState()
		{
			switch (_state)
			{
				case State.Init:
					break;
				case State.Play:
					break;
				case State.Win:
					break;
				case State.Lose:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void Update()
		{
			switch (_state)
			{
				case State.Init:
					break;
				case State.Play:
					break;
				case State.Win:
					break;
				case State.Lose:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}