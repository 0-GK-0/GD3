using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Glyph", menuName = "Glyphs/Base")]
public class BaseGlyph : SpellGlyph
{
    public override IEnumerator Execute() {yield return null;}
}
