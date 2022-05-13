using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    private Player player;

    void Start()
    {
        //Fetching the Player script from object named Player
        player = GameObject.Find("Player").GetComponent<Player>();

        //Referencing the text modifier from UI interface
        scoreText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        //Debug.Log(player.getPoints());

        //Updates the UI text with number of points gained
        //Updated score is fetched from the Player script's getPoints function
        scoreText.text = "Score: " + (player.getPoints()).ToString();
    }
    
}
