using NeoCapitalRPG.Model;
using NeoCapitalRPG.Services;
using System;
using System.Threading;

namespace NeoCapitalRPG.Services
{
    public static class UIService
    {
        public static void Titulo()
        {
            Console.Clear();
            ArteService.Mostrar("titulo");
            AudioService.TocarLoop(GameConfig.IntroMusic, 1.0f);
            Console.WriteLine("\nPressione ENTER para começar...");
            Console.ReadLine();
            AudioService.Parar();
        }

        public static Personagem CriarPersonagem()
        {
            Console.Clear();
            ArteService.Mostrar("personagem");

            Console.WriteLine("═══ CRIAÇÃO DE PERSONAGEM ═══\n");

            Console.Write("Digite o nome do seu caçador de créditos: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome)) nome = "Caçador";

            Console.WriteLine("\nEscolha o gênero:");
            Console.WriteLine("1 - Masculino");
            Console.WriteLine("2 - Feminino");

            string genero = "";
            while (true)
            {
                Console.Write("\nSua escolha: ");
                string escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    genero = "Masculino";
                    break;
                }
                else if (escolha == "2")
                {
                    genero = "Feminino";
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha inválida! Digite 1 ou 2.");
                    Console.ResetColor();
                }
            }

            var jogador = new Personagem(nome, genero);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nome} foi criado com sucesso!");
            Console.WriteLine($"Gênero: {genero}");
            Console.WriteLine($"HP: {jogador.HP} | Ataque: {jogador.Ataque}");
            Console.ResetColor();

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();

            return jogador;
        }

        // Introdução já com texto interno (compatível com chamadas sem args)
        public static void Introducao()
        {
            Console.Clear();
            ArteService.Mostrar("cidade");

            AudioService.TocarLoop(GameConfig.PrologoMusic, 0.8f);

            string[] introducao = {
                "O ano é 2147. A cidade Neo-Capital, construída sobre a antiga São Paulo,",
                "está mais populosa do que nunca. Isso a faz entrar em um ciclo inquebrável de violência.",
                "",
                "Megacorporações, controladas por donos sem rosto, ditam tudo:",
                "a comida, as informações… até o ar que você respira é monitorado.",
                "",
                "Não existem mais becos escuros, pois em cada esquina há um letreiro de neon",
                "tentando chamar sua atenção. Também não existem mais locais seguros:",
                "gangues cibernéticas extremamente violentas disputam o pouco de liberdade restante",
                "contra drones e droids mercenários da polícia.",
                "",
                "É aí que você entra: um(a) caçador(a) de créditos que, após mais uma briga",
                "genérica de bar, se vê preso em um dilema incomum.",
                "",
                "O problema? O mesmo dia se repete, sempre!",
                "",
                "Toda vez que o sol 'nasce', você desperta na mesma viela suja,",
                "com as mesmas oportunidades de luta.",
                "",
                "Talvez, se ficar forte o bastante, consiga abrir uma brecha e quebrar o ciclo..."
            };

            foreach (string linha in introducao)
            {
                EscreverTextoAnimado(linha);
            }

            AudioService.Parar();

            Console.WriteLine("\n\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public static void CabecalhoCiclo(Personagem p)
        {
            Console.Clear();
            ArteService.Mostrar("viela");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"═══ CICLO #{p.CiclosCompletados} ═══");
            Console.ResetColor();
        }

        public static void EscolherArma(Personagem jogador, Arma opcao1, Arma opcao2)
        {
            Console.Clear();
            AudioService.TocarLoop(GameConfig.MenuMusic, 0.8f);

            Console.WriteLine("\n═══ ESCOLHA SUA ARMA ═══");
            Console.WriteLine("Você encontra duas opções no chão da viela:");
            Console.WriteLine($"1 - {opcao1.Nome} (+{opcao1.Bonus} ATK) - {opcao1.Descricao}");
            Console.WriteLine($"2 - {opcao2.Nome} (+{opcao2.Bonus} ATK) - {opcao2.Descricao}");

            while (true)
            {
                Console.Write("\nSua escolha: ");
                string escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    jogador.ArmaEquipada = opcao1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nVocê equipou: {opcao1.Nome}");
                    Console.ResetColor();
                    break;
                }
                else if (escolha == "2")
                {
                    jogador.ArmaEquipada = opcao2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nVocê equipou: {opcao2.Nome}");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha inválida! Digite 1 ou 2.");
                    Console.ResetColor();
                }
            }

            AudioService.Parar();
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public static void ExibirStatus(Personagem p)
        {
            Console.WriteLine($"\n[STATUS] {p.Nome} | HP: {p.HP}/{p.HPMaximo} | ATK: {p.AtaqueTotal()} | XP: {p.XP}");
            Console.WriteLine($"[RECURSOS] Créditos: {p.Creditos} | Peças: {p.PecasColetadas} | Ciclo: {p.CiclosCompletados}");
        }

        public static void Fim()
        {
            Console.WriteLine("\nObrigado por jogar! Pressione ENTER para sair...");
            Console.ReadLine();
        }

        private static void EscreverTextoAnimado(string texto)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
    }
}

