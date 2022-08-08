using System.Collections;
using System.Collections.Generic;
using CharacterCreator2D;
using UnityEngine;
using UnityEngine.UI;
using static CharacterCreator2D.CharacterViewer;
using System.Linq;

public class WeaponJSONGenerator : MonoBehaviour
{
    public InputField OutputArea;
    private bool _processing = false;

    /// <summary>
    /// CharacterViewer displayed by this UICreator.
    /// </summary>
    [Tooltip("CharacterViewer displayed by this UICreator")]
    public CharacterCreator2D.CharacterViewer character;

    public void Update() {
        if (character == null) return;
        
    }

    public void Start() {
        GameObject handR = GameObject.Find("Hand R 0");
        if (handR != null) {
            Debug.Log("Deleting Hand");
            Destroy(handR);
        }
        HideAllBut("Pos_Weapon R");
    }

    public void GetJson() {
        SaveCharacterToJSON();
    }

    public void HideAllBut(string name) {

        GameObject weapon = GameObject.Find(name);
        if (weapon == null) return;
        HideUp(weapon.transform, "Root");
        
        
    }

    private void HideUp(Transform o, string stopAt) {
        if (o.name == stopAt) return;
        Transform parent = o.parent;
        foreach(Transform sibling in parent) {
            if (sibling == o) continue;
            sibling.gameObject.SetActive(false);
        }
        HideUp(o.parent, stopAt);
    }

     /// <summary>
    /// Save character's data as JSON file. Calling this function will save character's data with path defined in JSONRuntimePath field.
    /// </summary>
    public void SaveCharacterToJSON()
    {
        _processing = true;
        List<PartSlotData> result = new List<PartSlotData>();
        this.character._dataManager.GetPartSlotDataList(character, result);
        result = result.Where(data => data.category == SlotCategory.MainHand).ToList();
        
        this.OutputArea.text = "";
        foreach (PartSlotData slot in result) {
            string json = JsonUtility.ToJson(slot);
            this.OutputArea.text = json += "\n";
            Debug.Log(json);
        }
        // this.OutputArea.text = this.character.ToJSON();
        _processing = false;
    }

}
