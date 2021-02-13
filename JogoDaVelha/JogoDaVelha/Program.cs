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
            char resultadodojogo = '0';

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }
            Console.WriteLine("");

            do
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
                    resultadodojogo = verifica_Status(tabuleiro);
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
                    resultadodojogo = verifica_Status(tabuleiro);
                    // funções que testam e imprimem o jogo
                }
            } while (verifica_Status(tabuleiro) == '0'); //jogo finalizado

            if (resultadodojogo == '1')
            {
                Console.WriteLine("O jogador 1 venceu!");
            }
            else
            {
                Console.WriteLine("O jogador 2 venceu!");
            }
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
        static char verifica_Status(char[,] matriz)
        {
            if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2]) //
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0]) //
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[1, 0] == 'X' && matriz[1, 0] == matriz[1, 1] && matriz[1, 0] == matriz[1, 2])
            {
                return ('1');
            }
            else if (matriz[2, 0] == 'X' && matriz[2, 0] == matriz[2, 1] && matriz[2, 0] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[2, 0] == 'X' && matriz[2, 0] == matriz[1, 1] && matriz[2, 0] == matriz[0, 2])
            {
                return ('1');
            }
            else if (matriz[0, 1] == 'X' && matriz[0, 1] == matriz[1, 1] && matriz[0, 1] == matriz[2, 1])
            {
                return ('1');
            }
            else if (matriz[0, 2] == 'X' && matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2])
            {
                return ('2');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0])
            {
                return ('2');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
            {
                return ('2');
            }
            else if (matriz[1, 0] == 'O' && matriz[1, 0] == matriz[1, 1] && matriz[1, 0] == matriz[1, 2])
            {
                return ('2');
            }
            else if (matriz[2, 0] == 'O' && matriz[2, 0] == matriz[2, 1] && matriz[2, 0] == matriz[2, 2])
            {
                return ('2');
            }
            else if (matriz[2, 0] == 'O' && matriz[2, 0] == matriz[1, 1] && matriz[2, 0] == matriz[0, 2])
            {
                return ('2');
            }
            else if (matriz[0, 1] == 'O' && matriz[0, 1] == matriz[1, 1] && matriz[0, 1] == matriz[2, 1])
            {
                return ('2');
            }
            else if (matriz[0, 2] == 'O' && matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 2])
            {
                return ('2');
            }
            else
            {
                return ('0');
            }
        }
    }
}
