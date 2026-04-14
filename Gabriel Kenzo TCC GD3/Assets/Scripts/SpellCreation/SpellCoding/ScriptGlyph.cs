using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Glyph", menuName = "Glyphs/Script")]
public class ScriptGlyph : SpellGlyph
{
    public override IEnumerator Execute() {yield return null;}
}
