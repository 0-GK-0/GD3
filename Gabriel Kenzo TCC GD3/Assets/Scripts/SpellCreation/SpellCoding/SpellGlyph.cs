using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Glyph", menuName = "Glyphs/New Glyph")]
public abstract class SpellGlyph : ScriptableObject
{
    public enum GlyphType
    {
        Activation, //The way the spell is called
        Base, //Do something
        Augment, //Add an augmentation to another glyph
        Mode, //The way the spell is launched
        Script, //Things like wait, when, while, if etc.
    }
    public enum GlyphLevel //Minimum required comprehension level to use
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
    }

    [field: SerializeField] public string glyphName {get; private set;}

    [field: Header("Values")]
    [field: SerializeField] public int manaCost {get; private set;}
    [field: SerializeField] public float cdwnCost {get; private set;}

    [field: Header("GlyphType")]
    [field: SerializeField] public GlyphType glyphType {get; private set;}
    [field: SerializeField] public GlyphLevel glyphLevel {get; private set;}

    [field: Header("UI")]
    [field: SerializeField] public Sprite glyphIcon {get; private set;}

    public abstract IEnumerator Execute();
}