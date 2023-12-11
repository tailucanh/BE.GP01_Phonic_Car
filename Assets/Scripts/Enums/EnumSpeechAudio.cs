
using System.ComponentModel;

namespace Assets.Scripts.Enums
{
    public enum EnumSpeechAudio
    {
        [Description("Welcome to the big race!")]
        AudioIntro,
        [Description("tap hear move to the car")]
        AudioGuidingStart,
        [Description("Nice driving!")]
        AudioNiceDriving,
        [Description("Item Touch Collect")] 
        AudioItemTouch,
        [Description("Collect Item")]
        AudioCollectItem,
    }
}
