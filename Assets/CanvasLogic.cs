﻿using System.Collections;
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

}
