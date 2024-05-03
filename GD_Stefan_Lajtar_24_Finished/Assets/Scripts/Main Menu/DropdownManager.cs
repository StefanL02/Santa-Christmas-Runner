using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum difficulty
{
    EASY,
    MEDIUM,
    HARD,
    INSANE
}

public class DropdownManager : MonoBehaviour
{
    private TMP_Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        if(_dropdown == null)
        {
            Debug.Log("Dropdown not found");
        }

        _dropdown.ClearOptions();
        string[] enumNames = System.Enum.GetNames(typeof(difficulty));
        List<string> options = new List<string>(enumNames);
        _dropdown.AddOptions(options);

        SetInitialValue(difficulty.EASY);
        _dropdown.onValueChanged.AddListener(new UnityAction<int>(DropdownValueChanged));
    }

    void DropdownValueChanged(int value)
    {
        difficulty selectedDifficulty;
        if (System.Enum.TryParse(_dropdown.options[value].text, out selectedDifficulty))
        {
            switch (selectedDifficulty)
            {
                case difficulty.EASY:
                    Debug.Log("Selected: Easy");
                    SantaMovement.movementSpeed = 5f;
                    break;
                case difficulty.MEDIUM:
                    Debug.Log("Selected: Medium");
                    SantaMovement.movementSpeed = 7f;
                    break;
                case difficulty.HARD:
                    Debug.Log("Selected: Hard");
                    SantaMovement.movementSpeed = 8f;
                    break;
                case difficulty.INSANE:
                    Debug.Log("Selected: Insane");
                    SantaMovement.movementSpeed = 9f;
                    break;
                default:
                    Debug.LogError("Invalid difficulty");
                    break;
            }
        }
        else
        {
            Debug.LogError("Failed to parse difficulty");
        }
    }

    private void SetInitialValue(difficulty initialValue)
    {
        int index = Array.IndexOf(Enum.GetValues(typeof(difficulty)), initialValue);
        _dropdown.value = index;
    }
}
