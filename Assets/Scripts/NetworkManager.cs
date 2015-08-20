using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private string status = "";

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("alpha v0.1");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		if(status != PhotonNetwork.connectionStateDetailed.ToString ()){
			Debug.Log (PhotonNetwork.connectionStateDetailed.ToString ());
			status = PhotonNetwork.connectionStateDetailed.ToString ();
		}
	}

	void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby ();
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("Create Room");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		int side = 0;
		for (int i = 0; i < 10; i++) {
			GameObject myUnit = (GameObject)PhotonNetwork.Instantiate ("BRDM2 V3 MP", new Vector3 (Random.Range (10, 490), 0, Random.Range (10, 490)), Quaternion.identity, 0);
			if(i == 0)
				side = myUnit.GetComponent<PhotonView> ().viewID;
			myUnit.GetComponent<UnitMove> ().enabled = true;
			myUnit.GetComponent<UnitHealth> ().side = side;
		}
	}

}
