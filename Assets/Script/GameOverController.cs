using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour, IPointerClickHandler
{
	CanvasGroup Gameover;
	VikingController viking;
	Text fScore;
	Text reason;
	bool first=true;
	float endTime = 0;
	public void OnPointerClick(PointerEventData eventData)
	{
		SceneManager.LoadScene(0);
	}

	// Start is called before the first frame update
	void Start()
    {
		Gameover = GameObject.Find("GameOver_canvas").GetComponent<CanvasGroup>();
		viking = GameObject.Find("Viking_Axes").GetComponent<VikingController>();
		fScore = GameObject.Find("FinalScore").GetComponent<Text>();
		reason = GameObject.Find("Reason").GetComponent<Text>();
		Gameover.alpha = 0;
		Gameover.interactable = false;
		Gameover.blocksRaycasts = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (viking.gameover)
		{
			if (first)
			{
				endTime = Time.time;
				if (viking.seized) //in order to show monster seized you
				{
					GameObject.Find("Monster").GetComponent<MonsterController>().Seize();
					return;
				}

				Gameover.alpha = 1;
				Gameover.interactable = true;
				Gameover.blocksRaycasts = true;
				fScore.text = "Your score is " + (int)ScoreCal.score + " !\nYou survived " + (int)(endTime - StartGate.starttime) + " secs!";
				reason.text = viking.gameover_message;
				first = false;
			}
		}
    }
}
