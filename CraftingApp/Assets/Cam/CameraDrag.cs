using UnityEngine;

public class CameraDrag : MonoBehaviour
{
	public float dragSpeed = 8;
	public GameObject go;//objet autour duquel on veut tourner
	
	
	void Update()
	{
		
		
		if (Input.GetMouseButton(0)) {
			float origine = Input.GetAxis("Mouse X"); 
			//float origine2 = Input.GetAxis("Mouse Y"); 
			//je ne sais pas vraiment comment marche cette ligne, mais en tout cas ça fonctionne
			
			transform.RotateAround (go.transform.position, Vector3.up, origine*dragSpeed);
			//transform.RotateAround (go.transform.position, Vector3.left, origine2*dragSpeed);
			//fonction pour tourner autour d'un point précis
		}
		
	}
	
	
}