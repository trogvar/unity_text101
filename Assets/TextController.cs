using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {Cell, Mirror, Sheets, Lock, CellWithMirror, SheetsWithMirror, LockWithMirror, Freedom};
	private States gameState;
	
	// Use this for initialization
	void Start () {
		gameState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		print ("Current state: " + gameState);
		switch(gameState) {
			case States.Cell:
				StateCell();
				break;
			case States.Sheets:
				StateSheets();
				break;
			case States.Lock:
				StateLock();
				break;
			case States.Mirror:
				StateMirror();
				break;
			case States.CellWithMirror:
				StateCellWithMirror();
				break;
			case States.SheetsWithMirror:
				StateSheetsWithMirror();
				break;
			case States.LockWithMirror:
				StateLockWithMirror();
				break;
			case States.Freedom:
				StateFreedom();
				break;
		}
		if (gameState == States.Cell) {
			StateCell();
		} else if (gameState == States.Sheets) {
			StateSheets();
		} 
	}
	
	void StateCell() {
		text.text = "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed," +
				" a mirror on the wall, and the door is locked from the outside.\n\nPress S to view sheets," +
				" M to view Mirror, and L to view lock.";
				
		if (Input.GetKeyDown(KeyCode.S)) {
			gameState = States.Sheets;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			gameState = States.Lock;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			gameState = States.Mirror;
		}
	}
	
	void StateSheets() {
		text.text = "You can't believe you sleep in these things. Surely it's time somebody changed them. The " +
				"pleasures of prison life I guess!\n\n Press R to Return to roaming your cell";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			gameState = States.Cell;
		}
	}
	
	void StateLock() {
		text.text = "This is one of those button locks. You have no idea what the combination is. You wish you could " +
				"somehow see where the dirty fingerprints were, maybe that would help.\n\n Press R to return to roaming your cell";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			gameState = States.Cell;
		}
	}
	
	void StateMirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\nPress T to Take the mirror, or R to " +
					"return to roaming your cell";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			gameState = States.Cell;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			gameState = States.CellWithMirror;
		}
	}

	void StateCellWithMirror ()
	{
		text.text = "You are still in your cell, and you STILL want to escape! There are some dirty sheets on the" +
				" bed, a mark where the mirror was, and that pesky door is still there, and firmly locked!\n\n" +
				"Press S to view Sheets, or L to view Lock";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			gameState = States.SheetsWithMirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			gameState = States.LockWithMirror;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			gameState = States.Mirror;
		}
	}

	void StateSheetsWithMirror ()
	{
		text.text = "Holding a mirror in your hand doesn't make the sheets look any better.\n\n Press R to " +
					"return to roaming your stinky cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			gameState = States.CellWithMirror;
		}
	}

	void StateLockWithMirror ()
	{
		text.text = "You carefully put the mirror through the bars, and turn it around so you can see the lock." +
				" You can just make out fingerprints around the buttons. You press the dirty buttons, and hear " +
				"a click.\n\nPress O to Open, or R to return to your cell";
				
		if (Input.GetKeyDown(KeyCode.R)) {
			gameState = States.CellWithMirror;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			gameState = States.Freedom;
		}
	}

	void StateFreedom ()
	{
		text.text = "You are free!\n\n Press ANY key to play again";
		if (Input.anyKeyDown) {
			gameState = States.Cell;
		}
	}

}
