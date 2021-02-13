using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];
            int linhaj1, linhaj2, colunaj1, colunaj2;
            bool podecolocarpeca = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }

            //do
            {
                do
                {
                    Console.WriteLine("Jogador 1, informe a posição que deseja (linha e coluna): ");
                    Console.Write("Linha: ");
                    linhaj1 = int.Parse(Console.ReadLine());
                    Console.Write("Coluna: ");
                    colunaj1 = int.Parse(Console.ReadLine());
                    podecolocarpeca = posicao_disponivel(tabuleiro, linhaj1, colunaj1);
                } while (podecolocarpeca == false);
                {
                    tabuleiro[linhaj1, colunaj1] = 'X';
                    imprimir_Jogo(tabuleiro);
                    // funções que testam e imprimem o jogo
                }

                do
                {
                    Console.WriteLine("\nJogador 2, informe a posição que deseja (linha e coluna): ");
                    Console.Write("Linha: ");
                    linhaj2 = int.Parse(Console.ReadLine());
                    Console.Write("Coluna: ");
                    colunaj2 = int.Parse(Console.ReadLine());
                    podecolocarpeca = posicao_disponivel(tabuleiro, linhaj2, colunaj2);
                } while (podecolocarpeca == false);
                {
                    tabuleiro[linhaj2, colunaj2] = 'O';
                    imprimir_Jogo(tabuleiro);
                    // funções que testam e imprimem o jogo
                }

            } //while (jogofinalizado == true) //jogo finalizado

            Console.ReadKey();

        }
        static void imprimir_Jogo(char[,] matriz)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }
        static bool posicao_disponivel(char[,] matriz, int linha, int coluna)
        {
            if (matriz[linha, coluna] == '-')
            {
                return (true);
            }
            else
            {
                Console.WriteLine("Posição indisponível, escolha outra coordenada!!!\n");
                return (false);
            }
        }
    }
}
