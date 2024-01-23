using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject ChangeNameMenu;

    public void OnclickChangeName()
    {
        ChangeNameMenu.SetActive(true);

    }

    public void OnClickAccept()
    {
        if (!(2 < inputField.text.Length && inputField.text.Length < 10))
        {
            return;
        }
        GameManager.Instance.SetName(inputField.text);

        ChangeNameMenu.SetActive(false);
    }
}
