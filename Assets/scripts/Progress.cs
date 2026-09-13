using UnityEngine;
using TMPro;
public class Progress : MonoBehaviour
{
    public TMP_Text req;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    req.text = "You Need: ";

    }

    // Update is called once per frame
    void Update()
    {
        
        switch (DataStorage.Instance.CurrentEra)
        {
            case 1:
            req.text = "You Need: 10 Furniture, at least 30 humans and a well";
            break;
            case 2:
            req.text = "You Need: 20 Furniture, 30 tools at least 50 humans and a chapple";
            break;
            case 3:
            req.text = "You Need: 40 Furniture, 45 tools at least 70 humans and a school";
            break;
        }
        

        
    }
}
