using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace MyGame.Audio
{
public class SoundManager
{
private Dictionary<string, SoundEffect> soundEffects;public SoundManager()
    {
        soundEffects = new Dictionary<string, SoundEffect>();
    }

    public void LoadSound(string name, SoundEffect soundEffect)
    {
        soundEffects.Add(name, soundEffect);
    }

    public void PlaySound(string name)
    {
        if (soundEffects.TryGetValue(name, out SoundEffect soundEffect))
        {
            soundEffect.Play();
        }
    }
}
}