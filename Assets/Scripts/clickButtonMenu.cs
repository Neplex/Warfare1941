using UnityEngine;

public class clickButtonMenu : MonoBehaviour {
    public void onClick() {
		GameState.Instance.loadMenu();
	}
}