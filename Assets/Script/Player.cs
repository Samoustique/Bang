using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
 
	void Update()
	{
		if (GetComponent<NetworkView>().isMine)
		{
			InputMovement();
		}
		/*else
		{
			SyncedMovement();
		}*/
	}
	 
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}
 
    void InputMovement()
    {
        if (Input.GetKey(KeyCode.Z))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.Q))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * speed * Time.deltaTime);
    }
	
	/*void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = GetComponent<Rigidbody>().position;
			stream.Serialize(ref syncPosition);
		}
		else
		{
			stream.Serialize(ref syncPosition);
	 
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
	 
			syncStartPosition = GetComponent<Rigidbody>().position;
			syncEndPosition = syncPosition;
		}
	}*/
}
