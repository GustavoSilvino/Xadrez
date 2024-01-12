using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez.tabuleiro {
    abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int quantMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.cor = cor;
            this.tabuleiro = tab;
            this.quantMovimentos = 0;
        }

        public void incrementarQuantMovimentos() {
            this.quantMovimentos++;

        }

        public void decrementarQuantMovimentos() {
            this.quantMovimentos--;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}
