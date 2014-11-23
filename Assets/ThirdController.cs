using UnityEngine;
using System.Collections;

public class ThirdController : MonoBehaviour 
{
	// void Update()	- called b4 rendering a frame
	public float speed;
	public GUIText winText;
	public GUIText levelNum;
	public GUIText levelMesg;
	public GUIText pickupText;
	private int count;
	private int count2;
	private int levelno;
	public AudioClip Coin;
	public AudioClip Lvl;
	void Start()
	{
		count=0;
		count2=0;
		levelno=Application.loadedLevel;
		winText.text="";
		levelMesg.text="";
		pickupText.text="Collectables Left: " + (5-count2).ToString();
		levelNum.text="Level Number: " + levelno.ToString();
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return)) 
			{	
				Application.LoadLevel(levelno);
			}
		if (Input.GetKeyDown(KeyCode.Escape))
		{	
			Application.Quit();
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{	
			levelno=levelno+1;
			Application.LoadLevel(levelno);
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
			if(count2==5)
			{	
				other.gameObject.SetActive(false);
				count=count+1;
			}
		}
		if(other.gameObject.tag == "Pickup2")
		{
			other.gameObject.SetActive(false);
			count2=count2+1;
			pickupText.text="Collectables Left: " + (5-count2).ToString();
			audio.PlayOneShot(Coin);
		}
		if(count==1 && count2==5)
			{	audio.PlayOneShot(Lvl);
				winText.text="YOU WIN !!\n Press Enter to Restart OR Escape to Quit OR TAB to go to Next Level";
				if(levelno==2)
				{	levelMesg.text="YOU HAVE FINISHED THE GAME.........";
				}
			}	
    }
}
