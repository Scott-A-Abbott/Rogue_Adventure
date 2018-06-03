using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> bottom door
	// 2 --> top door
	// 3 --> left door
	// 4 --> right door

	private Room_Templates templates;
	private int rand;
	private bool spawned = false;

	void Start(){
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Templates>();
		Invoke("Spawn", 0.1f);
	}

	void Spawn(){
		if(!spawned){
			CheckOppening();
		}
		spawned = true;
	}

	void CheckOppening(){
		switch(openingDirection){
			case 1:
				//Need to spawn a room with a BOTTOM door
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				break;
			case 2:
				//Need to spawn a room with a TOP door			
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				break;
			case 3:
				//Need to spawn a room with a LEFT door			
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				break;
			case 4:
				//Need to spawn a room with a RIGHT door			
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				break;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint") && other.GetComponent<Room_Spawner>().spawned){
			Destroy(gameObject);
		}
	}

}
