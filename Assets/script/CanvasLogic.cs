using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLogic : MonoBehaviour
{

	public GameObject informationPanel;
	public GameObject destinationInfoPanel;
	public GameObject mainPanel;

	public List<Vector2> planeMapImagePos = new List<Vector2>();
	void Start()
	{

	}

	void Update()
	{

	}

	public void FlightInfoButton_Clicked()
	{
		informationPanel.SetActive(true);
		mainPanel.SetActive(false);
	}

	public void FlightInfoCloseButton_Clicked()
	{
		informationPanel.SetActive(false);
		mainPanel.SetActive(true);
	}

	public void DestinationInfoButton_Cliked()
	{
		destinationInfoPanel.SetActive(true);
		mainPanel.SetActive(false);
	}

	public void InformationPanelCloseButton_Click()
	{
		destinationInfoPanel.SetActive(false);
		mainPanel.SetActive(true);
	}
	public void MovieButton_Click(){
		string movie;
		switch (this.name) {
		case "ButtonJaguar":
			movie = "StreamingAssets/Trailer Colombia Magia Salvaje.mp4";
			break;
		case "ButtonFrog":
			movie = "StreamingAssets/Trailer Colombia Magia Salvaje.mp4";
			break;
		case "ButtonSnake":
			movie = "StreamingAssets/Trailer Colombia Magia Salvaje.mp4";
			break;
		case "ButtonCondor":
			movie = "StreamingAssets/Trailer Colombia Magia Salvaje.mp4";
			break;
		default:
			break;
		}
	}

}
