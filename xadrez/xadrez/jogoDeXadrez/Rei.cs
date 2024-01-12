using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez.tabuleiro;

namespace xadrez.jogoDeXadrez {
    internal class Rei : Peca {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p != null && p is Torre && p.cor == cor && quantMovimentos == 0;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            //norte
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //leste
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //sul
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //oeste
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //roque (Jogada Especial)
            if(quantMovimentos == 0 && !partida.xeque) {
                //roque pequeno
                Posicao posicaoT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(testeTorreParaRoque(posicaoT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                //roque grande
                Posicao posicaoT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posicaoT2)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
