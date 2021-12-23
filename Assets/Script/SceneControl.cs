using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour, IPointerClickHandler
{
	CanvasGroup Help, Menu;
	void Start()
	{
		Help = GameObject.Find("HelpCanvas").GetComponent<CanvasGroup>();
		Menu = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(eventData.selectedObject.name);
		if (eventData.selectedObject.name == "GameStart")
		{
			SceneManager.LoadScene(1);
		}
		else if(eventData.selectedObject.name == "GameEnd")
		{
			Application.Quit();
		}
		else if (eventData.selectedObject.name == "Help")
		{
			Help.alpha = 1;
			Help.interactable = true;
			Help.blocksRaycasts = true;
			Menu.alpha = 0;
			Menu.interactable = false;
			Menu.blocksRaycasts = false;
		}
		else if (eventData.selectedObject.name == "CloseHelp")
		{
			Help.alpha = 0;
			Help.interactable = false;
			Help.blocksRaycasts = false;
			Menu.alpha = 1;
			Menu.interactable = true;
			Menu.blocksRaycasts = true;
		}
	}
}
