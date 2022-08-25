using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AvatarDropDown : MonoBehaviour
{
    List<string> labels = new List<string>() {
    "Astronaut",
    "Duck",
    "Llama"
    };

    public TMP_Dropdown dropdown;
    public TextMeshProUGUI selectedLabel;

    public void Dropdown_IndexChanged(int index){
        //Read the index and display the selected label
        selectedLabel.text = labels[index] + " selected!";
        //Send selection to the Menu Controller
        MenuController.MC.OnClickCharacterPick(index);
        Debug.Log(labels[index]);

        // // Open Pre-Questionairre if label 1 selected
        // if (labels[index] == labels[1])
        // {
        //     Application.OpenURL("https://forms.gle/6YMJJJjBC1FkjCtp6");
        // }
        // // To do: Add a confirm button

        // // Open training video if label 2 selected
        // if (labels[index] == labels[2])
        // {
        //     Application.OpenURL("https://youtu.be/yEqyRM5Hu2g");
        // }

        // // Open Post-Questionairre if label 4 selected
        // if (labels[index] == labels[4])
        // {
        //     Application.OpenURL("https://forms.gle/vicwfKatg1bKDuNk8");
        // }
    }
    
    void Start(){
        PopulateList();
    }

    void PopulateList(){
        dropdown.AddOptions(labels);
    }
}