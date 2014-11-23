#pragma strict

function OnGUI () 
{	//head="dsd";
	//GUI.Label(Rect (0,0,100,50),head);
	if (GUI.Button (Rect (300,700,150,50), "START GAME")) 
	{	
		Application.LoadLevel(1);
	}
	if (GUI.Button (Rect (500,700,150,50), "QUIT GAME")) 
	{	
		Application.Quit();
	}
}