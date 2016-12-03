using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLogic : MonoBehaviour
{

	public GameObject informationPanel;
	public GameObject destinationInfoPanel;

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
	}

	public void FlightInfoCloseButton_Clicked()
	{
		informationPanel.SetActive(false);
	}

	public void DestinationInfoButton_Cliked()
	{
		destinationInfoPanel.SetActive(true);
	}

	public void InformationPanelCloseButton_Click()
	{
		destinationInfoPanel.SetActive(false);
	}

}
