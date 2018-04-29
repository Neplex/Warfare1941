using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onExistPlayBossMusic : MonoBehaviour {

	void Start () {
		SoundState.Instance.startBossMusic();
	}

	private void OnDestroy() {
		SoundState.Instance.startGameMusic();
	}
	
}
