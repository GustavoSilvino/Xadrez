﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez.tabuleiro;

namespace xadrez.jogoDeXadrez {
    class PosicaoXadrez {
        public char coluna {  get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.linha = linha;
            this.coluna = coluna;

        }
        public Posicao toPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString() {
            return "" + coluna + linha;

        }
    }
}
