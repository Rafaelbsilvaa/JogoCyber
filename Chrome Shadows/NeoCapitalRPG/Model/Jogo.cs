using NeoCapitalRPG.Model;
using NeoCapitalRPG.Services;
using System;

namespace NeoCapitalRPG.Model
{
    public class Jogo
    {
        private Personagem jogador;
        private bool jogoAtivo = true;

        // Armas disponíveis
        private Arma canoFerro = new Arma("Cano de Ferro", 5, "Uma arma improvisada, pesada mas eficaz");
        private Arma punhal = new Arma("Punhal", 3, "Rápido e silencioso, perfeito para ataques furtivos");
        private Arma canoBlindsado = new Arma("Cano Blindado", 10, "Melhoramento do cano de ferro com peças coletadas");

        // Método público compatível com seu código anterior
        public void IniciarJogo()
        {
            UIService.Titulo();
            jogador = UIService.CriarPersonagem();
            UIService.Introducao();

            while (jogoAtivo && jogador.HP > 0)
            {
                LoopPrincipal();
            }

            UIService.Fim();
        }

        private void LoopPrincipal()
        {
            jogador.CiclosCompletados++;

            UIService.CabecalhoCiclo(jogador);

            // Se ainda não tem arma, oferecer escolha com 2 opções
            if (jogador.ArmaEquipada == null)
            {
                UIService.EscolherArma(jogador, canoFerro, punhal);
            }

            UIService.ExibirStatus(jogador);

            if (VerificarFinais()) return;

            // Chama menu principal passando ações
            MenuService.MenuPrincipal(
                jogador,
                irFerroVelho: () => IrParaFerroVelho(),
                irMercado: () => IrParaMercadoAbandonado(),
                verificarInventario: () => VerificarInventario(),
                melhorarArma: () => MelhorarArma(),
                tentarRomper: () => { FinalBom(); }
            );
        }

        private void IrParaFerroVelho()
        {
            Console.Clear();
            ArteService.Mostrar("ferro_velho");
            Console.WriteLine("═══ FERRO-VELHO ═══");

            Inimigo drone = new Inimigo("Drone Policial Antigo", 30, 8, 5, 10);
            bool venceu = CombateService.Batalha(jogador, drone);
            if (venceu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVocê encontra peças úteis entre os destroços!");
                jogador.PecasColetadas++;
                jogador.GanharXP(drone.XPRecompensa);
                jogador.Creditos += drone.CreditosRecompensa;
                Console.WriteLine($"Peças coletadas: +1 | XP: +{drone.XPRecompensa} | Créditos: +{drone.CreditosRecompensa}");
                Console.ResetColor();
            }

            Console.WriteLine("\nVocê retorna para a viela...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        private void IrParaMercadoAbandonado()
        {
            Console.Clear();
            ArteService.Mostrar("mercado");
            Console.WriteLine("═══ MERCADO ABANDONADO ═══");

            Inimigo gangster = new Inimigo("Membro Chrome Shadows", 45, 12, 8, 25);
            bool venceu = CombateService.Batalha(jogador, gangster);

            if (venceu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVocê saqueia os créditos do gangster!");
                jogador.GanharXP(gangster.XPRecompensa);
                jogador.Creditos += gangster.CreditosRecompensa;
                Console.WriteLine($"XP: +{gangster.XPRecompensa} | Créditos: +{gangster.CreditosRecompensa}");
                Console.ResetColor();
            }

            Console.WriteLine("\nVocê retorna para a viela...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        private bool IniciarBatalha(Inimigo inimigo)
        {
            // Caso precise de um wrapper local; mas agora usamos CombateService direto
            return CombateService.Batalha(jogador, inimigo);
        }

        private void VerificarInventario()
        {
            Console.WriteLine("\n═══ INVENTÁRIO ═══");
            if (jogador.ArmaEquipada != null)
                Console.WriteLine($"Arma equipada: {jogador.ArmaEquipada.Nome} (+{jogador.ArmaEquipada.Bonus} ATK)");
            Console.WriteLine($"Créditos: {jogador.Creditos}");
            Console.WriteLine($"Peças coletadas: {jogador.PecasColetadas}");
            Console.WriteLine($"XP: {jogador.XP}");
            Console.WriteLine($"Ciclos completados: {jogador.CiclosCompletados}");
        }

        private void MelhorarArma()
        {
            if (jogador.PecasColetadas >= 3 && jogador.ArmaEquipada != canoBlindsado)
            {
                Console.WriteLine("\nDeseja melhorar sua arma usando 3 peças? (s/n): ");
                string escolha = Console.ReadLine().ToLower();
                if (escolha == "s" || escolha == "sim")
                {
                    jogador.PecasColetadas -= 3;
                    jogador.ArmaEquipada = canoBlindsado;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Arma melhorada com sucesso!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (jogador.ArmaEquipada == canoBlindsado)
                    Console.WriteLine("Sua arma já está no máximo!");
                else
                    Console.WriteLine("Você precisa de 3 peças para melhorar sua arma!");
                Console.ResetColor();
            }
        }

        private bool VerificarFinais()
        {
            Action<Personagem> finalAction;
            if (FinalService.Verificar(jogador, out finalAction))
            {
                finalAction?.Invoke(jogador);
                jogoAtivo = false;
                return true;
            }
            return false;
        }

        private void FinalBom()
        {
            ArteService.Mostrar("glitch");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("═══ O ROMPIMENTO DO CICLO ═══\n");
            Console.ResetColor();
            Console.WriteLine("Você venceu o ciclo...");
            jogoAtivo = false;
        }
    }
}


