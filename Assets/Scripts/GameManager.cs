using bowlingscoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform pinPos;
	public GameObject pinRack;
	public GameObject ball;
	public string scene;
	public Vector3 pos;

    public Text scoreText;
	public Text pinsText;
	public Text rollText;
	public Text boardText;
	public static int score = 0;
	public int fallen = 0;
	public int rolls;
	public int frameI;
	public float time = 0;

    private PinniBoy[] pins;
	private Transform pr;
    private GameObject rack;

	private ScoreManager scoreboard;

	// Use this for initialization
	void Start () {
        rack = Instantiate(pinRack, pinPos);
        pr = rack.GetComponentInChildren<Transform>();
		pins = pr.GetComponentsInChildren<PinniBoy>();
		Debug.Log(pins[0].hasFallen);
		NewGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Reset();
        }
		if (Input.GetButtonDown("Fire3"))
		{
			//Instantiate(pinRack, transform);
		}
		if (OVRInput.GetDown(OVRInput.Button.Three))
		{
			Instantiate(ball, pos, Quaternion.identity);
		}
		/*
		 * This will need to be changed in order to allow for multiple rolls in one frame
		 * and to keep track of what frame we're in so we know where to put the scores
		 */
		//Rolls();
		boardText.text = scoreboard.PrintScoreboard();
	}

	public void Roll()
	{
		StartCoroutine(CountPins());
	}

	public IEnumerator CountPins()
	{
		rolls++;
		fallen = 0;
		yield return new WaitForSecondsRealtime(time);
		foreach(PinniBoy p in pins)
		{
			
			if (p.hasFallen)
			{
				fallen++;
			} else
			{
			}
		}
		if (rolls == 1)
		{
			scoreboard.SetFrame(frameI, fallen, 0);
		}
		else if (rolls == 2)
		{
			Destroy(rack.gameObject);
			scoreboard.AddFrame(frameI, 0, fallen);
			frameI++;
			rolls = 0;
			rack = Instantiate(pinRack, pinPos);
		}
		if (frameI == 10) frameI = 0;
		scoreText.text = "Frame: " + frameI;
		pinsText.text = "Pins: " + fallen;
		rollText.text = "Roll: " + rolls;
	}
	
	public void Reset()
	{
		SceneManager.LoadScene(scene);
	}

	public void NewGame()
	{
		/*
		 * This is where we will put the code for when a new game of bowling starts
		 * Not only when the game is run, but maybe include a way to restart the game
		 * or start a new game whenever the current game is over.
		 */
		 //Creates a new scoreboard, called every time we need to track score for a player
		scoreboard = new ScoreManager();
	}
}
