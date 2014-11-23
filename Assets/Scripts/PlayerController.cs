using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// void Update()	- called b4 rendering a frame
	public float speed;
	public GUIText winText;
	public GUIText levelNum;
	public GUIText levelMesg;
	private int count;
	private int levelno;
	void Start()
	{
		count=0;
		levelno=Application.loadedLevel+1;
		winText.text="";
		levelMesg.text="";
		levelNum.text="Level Number: " + levelno.ToString();
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return)) 
			{	
				Application.LoadLevel(levelno-1);
			}
		if (Input.GetKeyDown(KeyCode.Escape))
		{	
			Application.Quit();
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{	
			levelno=levelno+1;
			Application.LoadLevel(levelno-1);
		}
	} 
	void FixedUpdate()	//called b4 physics calculations - applying force to move body 
	{	float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		rigidbody.AddForce(movement*speed*Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) 
	{
        if(other.gameObject.tag == "Pickup")
		{
			other.gameObject.SetActive(false);
			count=count+1;
			if(count==1)
			{
				winText.text="YOU WIN !!\n Press Enter to Restart OR Escape to Quit OR TAB to go to Next Level";
				if(levelno==2)
				{	levelMesg.text="YOU HAVE FINISHED THE GAME.........";
				}
			}
		}
    }
}
