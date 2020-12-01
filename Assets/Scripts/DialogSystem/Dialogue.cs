using System;

[Serializable]
public class Dialog
{
    private string characterName;
    private string dialogMessage;

    public string CharacterName { get => characterName;}
    public string DialogMessage { get => dialogMessage;}

    public Dialog(string characterName, int characterPosition, string dialog)
    {
        this.characterName = characterName;
        this.dialogMessage = dialog;
    }
}
