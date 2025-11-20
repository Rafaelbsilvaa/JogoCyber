using NeoCapitalRPG.Model;
using System;


namespace NeoCapitalRPG.Services
{
    public static class FinalService
    {
        public static bool Verificar(Personagem p, out Action<Personagem> finalAction)
        {
            finalAction = null;
            if (p == null) return false;

            if (p.XP >= 100 && p.HP > 0)
            {
                finalAction = Finais.Bom;
                return true;
            }

            if (p.CiclosCompletados >= 5 && p.XP < 20)
            {
                finalAction = Finais.Ruim;
                return true;
            }

            if (p.HP <= 0)
            {
                finalAction = Finais.Morte;
                return true;
            }

            return false;
        }
    }

    public static class Finais
    {
        public static void Bom(Personagem p)
        {
            Console.Clear();
            Console.WriteLine("═══ FINAL BOM ═══");
            Console.WriteLine("Você rompeu o ciclo!");
            // ... mais texto
        }

        public static void Ruim(Personagem p)
        {
            Console.Clear();
            Console.WriteLine("═══ FINAL RUIM ═══");
            // ...
        }

        public static void Morte(Personagem p)
        {
            Console.Clear();
            Console.WriteLine("═══ GAME OVER ═══");
            // ...
        }
    }
}


