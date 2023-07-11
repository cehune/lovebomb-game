using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextArchitext
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;
    public TMP_Text text => tmpro_ui != null ? tmpro_ui : tmpro_world;
}
