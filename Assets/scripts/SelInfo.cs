using UnityEngine;
using TMPro;
public class SelInfo : MonoBehaviour
{
    public TMP_Text Price;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    Price.text = "Price: ";

    }

    // Update is called once per frame
    void Update()
    {

        switch(LeChoiceSystem.WeBeChoosing)
        {
            case ("Nothing"):
                break;
            case ("Farm"):
            Price.text = "Price: Wood: 10, Stone: 5" ;
            break;
            case ("Storage"):
            Price.text = "Price: Wood: 10" ;
            break;
            case ("Forestry"):
            Price.text = "Price: Wood: 5, Stone: 5" ;
            break;
            case ("Housing"):
            Price.text = "Price: Wood: 10, Stone: 5" ;
            break;
            case ("Saw"):
            Price.text = "Price: Wood: 10, Stone: 5" ;
            break;
            case ("Workshop"):
            Price.text = "Price: Wood: 10, Stone: 10, Bricks: 10" ;
            break;
            case ("Mine"):
            Price.text = "Price: Wood: 10" ;
            break;
            case ("Well"):
            Price.text = "Price: Wood: 5, Stone: 10" ;
            break;
            case ("Smelter"):
            Price.text = "Price: Wood: 10, Stone: 10" ;
            break;
            case ("Chapel"):
            Price.text = "Wood: 10, Stone: 20, Bricks: 10, Furniture: 5, Tools: 5" ;
            break;
            case ("School"):
            Price.text = "Price: Wood: 30, Stone: 20, Bricks: 20, Furniture: 10, Tools: 10" ;
            break;
        }
    }
}
