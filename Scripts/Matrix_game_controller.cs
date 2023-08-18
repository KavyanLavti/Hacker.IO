using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Matrix_game_controller : MonoBehaviour
{
    [Header("instanitate_button")]
    public Button instantiate_prefab;
    public Transform parent_transform;
    Matrix_game matrix_Game;
    TextMeshProUGUI question;
    MatrixButton matrixButton;

    [Header("Sprites")]
    public Sprite onClickedSprite;
    public Sprite RegularSprite;
    public Image[] imagesInButton;
    private void Start()
    {
        matrix_Game = parent_transform.GetComponent<Matrix_game>();
    }
    public void Add_Matrix_buttons()
    {
        question = GetComponentInChildren<TextMeshProUGUI>();
        for (int i = 0; i < matrix_Game.rows + matrix_Game.colms; i++)
        {
            Button newButton = Instantiate(instantiate_prefab);
            newButton.transform.SetParent(parent_transform);
            newButton.onClick.AddListener(() => ButtonClick(newButton));
            matrixButton = newButton.GetComponent<MatrixButton>();
            matrixButton.numberValue = i+1;
            imagesInButton[i] = newButton.GetComponent<Image>();
            //TextMeshProUGUI textMeshProUGUI = newButton.GetComponent<TextMeshProUGUI>();
            //textMeshProUGUI.text = i.ToString();

        }
    }
    public void ButtonClick(Button button)
    {

    }
    //IEnumerator displayNumber()
    //{
    //    return;
    //}
}
