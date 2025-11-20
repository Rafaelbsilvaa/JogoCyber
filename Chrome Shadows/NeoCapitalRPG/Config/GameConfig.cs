using System.Collections.Generic;

namespace NeoCapitalRPG
{
    public static class GameConfig
    {
        public static string IntroMusic = @"Music\musica-inicial.mp3";

        public static Dictionary<string, string> Artes = new Dictionary<string, string>

        {
            { "titulo", @"(ASCII art aqui)" },
            { "viela", @"(...)" },
            { "cidade", @"(...)" },
            { "glitch", @"(...)" }
        };
    }
}

