using NeoCapitalRPG.Model;
using System;

namespace NeoCapitalRPG.Services
{
    public static class MenuService
    {
        public static void MenuPrincipal(Personagem jogador, Action irFerroVelho, Action irMercado, Action verificarInventario, Action melhorarArma, Action tentarRomper)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n═══ VIELA INICIAL ═══");
                Console.WriteLine("1 - Ferro-Velho (Batalhar contra drones antigos)");
                Console.WriteLine("2 - Mercado Abandonado (Enfrentar gangue Chrome Shadows)");
                Console.WriteLine("3 - Verificar inventário");
                Console.WriteLine("4 - Melhorar arma (requer peças)");

                if (jogador.XP >= 100)
                    Console.WriteLine("5 - Tentar romper o ciclo (Finalizar o jogo)");

                Console.Write("\nSua escolha: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        irFerroVelho?.Invoke();
                        return;
                    case "2":
                        irMercado?.Invoke();
                        return;
                    case "3":
                        verificarInventario?.Invoke();
                        break;
                    case "4":
                        melhorarArma?.Invoke();
                        break;
                    case "5":
                        if (jogador.XP >= 100)
                        {
                            tentarRomper?.Invoke();
                            return;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Você ainda não tem XP suficiente para romper o ciclo!");
                            Console.ResetColor();
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public static string EscolherAcaoCombate()
        {
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Defender (reduz dano recebido pela metade)");
            Console.Write("Sua ação: ");
            return Console.ReadLine();
        }
    }
}


