﻿/// <summary>
/// ZombieSpawn.cs
/// Last Modified: 2016-12-19
/// Created By: Eddie Song
/// Last Modified By: Eddie Song
/// Summary: this script has one simple task: to instantiate zombie prefabs periodically.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

	private MainGameController gameController;
	[SerializeField]
	private GameObject[] zombiePrefabs;

	// Use this for initialization
	void Start ()
	{
		gameController = GameObject.Find ("GameController").GetComponent<MainGameController> ();
		StartCoroutine (CheckForSpawn ());
	}

	IEnumerator CheckForSpawn ()
	{
		while (true) {
			if (gameController.numZombies < gameController.maxNumZombies) {
				Instantiate (zombiePrefabs [Random.Range (0, zombiePrefabs.Length)], transform.position, Quaternion.identity);
				gameController.numZombies++;
			}
			yield return new WaitForSeconds (5.0f);
		}
	}
}
