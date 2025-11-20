using NeoCapitalRPG.Model;
using System;
using System.Threading;

namespace NeoCapitalRPG.Services
{
    public static class CombateService
    {
        private static Random random = new Random();

        public static bool Batalha(Personagem jogador, Inimigo inimigo)
        {
            while (jogador.HP > 0 && inimigo.HP > 0)
            {
                UIService.ExibirStatus(jogador);
                string acao = MenuService.EscolherAcaoCombate();

                if (acao == "1") Atacar(jogador, inimigo);

                if (inimigo.HP > 0)
                    AtacarInimigo(jogador, inimigo, acao == "2");

                Thread.Sleep(700);
            }
            return jogador.HP > 0;
        }

        private static void Atacar(Personagem jogador, Inimigo inimigo) { /* reduzido */ }
        private static void AtacarInimigo(Personagem jogador, Inimigo inimigo, bool defendendo) { /* reduzido */ }
    }
}

