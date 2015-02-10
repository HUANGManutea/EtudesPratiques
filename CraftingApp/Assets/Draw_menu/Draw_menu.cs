using UnityEngine;
using System.Collections;



public class Draw_menu : MonoBehaviour {

	private const int COULEUR = 0;
	private const int TOOLS = 1;
	private const int DIAM = 2;

	public enum Tools {PENCIL,ERASER,BUCKET};
	public enum Diam {SMALL = 5,MEDIUM = 10,LARGE = 20};

	public Color color;
	public Tools tool;
	public Diam diam;


	public UnityEngine.UI.Button colorSelect;
	public UnityEngine.UI.Button toolSelect;
	public UnityEngine.UI.Button diamSelect;

	public void Start(){
		setBlack ();
		setPencil ();
		setMedium ();
	}

	public void selectionne(string c,int type){

		GameObject bouton = GameObject.Find (c);

		switch (type) {
				case COULEUR:
						if (colorSelect != null) {
								colorSelect.interactable = true;
						}

						
						if (bouton != null) {
								colorSelect = bouton.GetComponent<UnityEngine.UI.Button> ();
						}
		

						colorSelect.interactable = false;
				
							break;
				case TOOLS:
					if (toolSelect != null) {
						toolSelect.interactable = true;
					}
					
					if (bouton != null) {
						toolSelect = bouton.GetComponent<UnityEngine.UI.Button> ();
					}
					
					
					toolSelect.interactable = false;
					
					break;

				case DIAM:
					if (diamSelect != null) {
						diamSelect.interactable = true;
					}
					
					if (bouton != null) {
						diamSelect = bouton.GetComponent<UnityEngine.UI.Button> ();
					}
					
					
					diamSelect.interactable = false;
					
					break;
				}
		}


	//Selection des couleurs

	public void setRed(){
		color = Color.red;

		selectionne ("red",COULEUR);

		}

	public void setBlue(){
		color = Color.blue;

		selectionne ("blue",COULEUR);
	}

	public void setGreen(){
		color = Color.green;

		selectionne ("green",COULEUR);
	}

	public void setYellow(){
		color = Color.yellow;

		selectionne ("yellow",COULEUR);
	}

	public void setBlack(){
		color = Color.black;

		selectionne ("black",COULEUR);
	}

	public void setCyan(){
		color = Color.cyan;

		selectionne ("cyan",COULEUR);
	}

	public void setMagenta(){
		color = Color.magenta;
		
		selectionne ("magenta",COULEUR);
	}

	public void setWhite(){
		color = Color.white;
		
		selectionne ("white",COULEUR);
	}

	//Selection des outils
	
	public void setPencil(){
		tool = Tools.PENCIL;
		
		selectionne ("pencil",TOOLS);
		
	}
	public void setEraser(){
		tool = Tools.ERASER;
		
		selectionne ("eraser",TOOLS);
		
	}
	public void setBucket(){
		tool = Tools.BUCKET;
		
		selectionne ("bucket",TOOLS);
		
	}

	//Selection diamètre
	public void setSmall(){
		diam = Diam.SMALL;
		
		selectionne ("small",DIAM);
		
	}
	public void setMedium(){
		diam = Diam.MEDIUM;
		
		selectionne ("medium",DIAM);
		
	}
	public void setLarge(){
		diam = Diam.LARGE;
		
		selectionne ("large",DIAM);
		
	}



	public Color getColor(){
				return color;
		}
	public Tools getTool(){
		return tool;
	}
	public Diam getDiam(){
		return diam;
	}
}
