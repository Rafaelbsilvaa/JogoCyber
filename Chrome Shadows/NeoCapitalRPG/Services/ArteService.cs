using System;
using System.Collections.Generic;

namespace NeoCapitalRPG.Services
{
    public static class ArteService
    {
        private static Dictionary<string, string[]> artes = new Dictionary<string, string[]>
        {
            {
                "titulo", new string[]
                {
                    @"███╗   ██╗███████╗ ██████╗      ██████╗ █████╗ ████████╗██████╗ ██╗",
                    @"████╗  ██║██╔════╝██╔═══██╗    ██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██║",
                    @"██╔██╗ ██║█████╗  ██║   ██║    ██║     ███████║   ██║   ██████╔╝██║",
                    @"██║╚██╗██║██╔══╝  ██║   ██║    ██║     ██╔══██║   ██║   ██╔══██╗██║",
                    @"██║ ╚████║███████╗╚██████╔╝    ╚██████╗██║  ██║   ██║   ██║  ██║███████╗",
                    @"╚═╝  ╚═══╝╚══════╝ ╚═════╝      ╚═════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝"
                }
            },
            {
                "cidade", new string[]
                {
                    @"   ╔════════════════════════════════╗",
                    @"   ║   NEOCAPITAL — DISTRITO 22     ║",
                    @"   ╚════════════════════════════════╝",
                    @"      ║║║║║║║║║║║║║║║║║║║║║║║║║║║║",
                    @"      ▓▓▓███▓▓▓▓▓█▓███▓█▓▓██▓██▓▓▓"
                }
            },
            {
                "viela", new string[]
                {
                    @"  ▓▓▓▒▒▒▒▒░░░ ── VIELA ── ░░░▒▒▒▒▒▓▓▓",
                    @"    ▒▒ Lixo, neon quebrado e cheiro de ozônio ▒▒"
                }
            },
            {
                "ferro_velho", new string[]
                {
                    @" ██████ FERRO-VELHO ██████ ",
                    @" Robôs descartados formam montanhas metálicas…"
                }
            },
            {
                "mercado", new string[]
                {
                    @" ▓▓▓▓ MERCADO ABANDONADO ▓▓▓▓ ",
                    @" Letreiros piscam sem energia, caixas arrombadas…"
                }
            },
            {
                "glitch", new string[]
                {
                    @"█░█░█░ R O M P E N D O ░█░█░█",
                    @"░█░█░ O  C I C L O ░█░█░",
                    @"█░█░█░█░█░█░█░█░█░█░█░█"
                }
            }
        };

        public static void Mostrar(string nomeArte)
        {
            Console.Clear();

            if (artes.ContainsKey(nomeArte))
            {
                foreach (string linha in artes[nomeArte])
                {
                    Console.WriteLine(linha);
                }
            }
            else
            {
                Console.WriteLine($"[Arte: {nomeArte}]");
            }

            Console.WriteLine(); 
        }
    }
}


