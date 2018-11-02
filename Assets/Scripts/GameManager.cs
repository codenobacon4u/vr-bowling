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

    public Text scoreText;
    public static int score = 0;
	public int fallen = 0;

    private Transform[] pins;
    private GameObject setOfPins;

	private ScoreManager scoreboard;

	// Use this for initialization
	void Start () {
        setOfPins = Instantiate(pinRack, pinPos);
        pins = setOfPins.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
        {
            Reset();
        }
		if (Input.GetButtonDown("Fire3"))
		{
			Instantiate(pinRack, transform);
		}
		if (Input.GetButtonDown("Fire4"))
		{
			Instantiate(ball, transform);
		}
		/*
		 * This will need to be changed in order to allow for multiple rolls in one frame
		 * and to keep track of what frame we're in so we know where to put the scores
		 */
		foreach (Transform pin in pins)
        {
            if (pin.GetComponent<PinniBoy>().hasFallen)
            {
                score++;
            }
        }
        scoreText.text = "Pins knoncked down: " + score;
	}

	public IEnumerator CountPins()
	{
		yield return new WaitForSeconds(3f);
		foreach (Transform pin in pins)
		{
			if (pin.GetComponent<PinniBoy>().hasFallen)
			{
				fallen++;
			}
		}
		scoreboard.SetFrame(0, fallen, 0);
	}
	
	public void Reset()
	{
		SceneManager.LoadScene(scene);
		setOfPins = Instantiate(pinRack, pinPos);
        pins = setOfPins.GetComponentsInChildren<Transform>();
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
