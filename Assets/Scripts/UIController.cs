using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Text HpBar;

	[SerializeField]
	public Text Progress;
	PlayerController player_cont;


	void Start()
	{
	 	player_cont = player.GetComponent<PlayerController>();
		HpBar.text = player_cont.Health + "/" + player_cont.maxHealth;
		Progress.text = player_cont.CurrentProgress + "/" +player_cont.progress;
	}

    // Update is called once per frame
    void Update()
    {
		HpBar.text = player_cont.Health + "/" + player_cont.maxHealth;
		Progress.text = player_cont.CurrentProgress + "/" + "5";
    }
}
