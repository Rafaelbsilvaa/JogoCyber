using System;

namespace NeoCapitalRPG.Services
{
    public static class AudioService
    {
        private static bool tocando = false;

        public static void TocarLoop(string nomeArquivo, float volume)
        {
            
            tocando = true;
        }

        public static void Parar()
        {
            tocando = false;
        }
    }
}


