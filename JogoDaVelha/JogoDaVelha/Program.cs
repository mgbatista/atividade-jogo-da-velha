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
            char resultadodojogo;
            string nomejog1, nomejog2;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }

            Console.WriteLine(">>> JOGO DA VELHA <<<\n");
            Console.WriteLine("Informe o nome dos jogadores:\n");
            Console.Write("Jogador 1: ");
            nomejog1 = Console.ReadLine();
            Console.Write("Jogador 2: ");
            nomejog2 = Console.ReadLine();


            do
            {
                    do
                    {
                        Console.WriteLine("\n" + nomejog1 + ", informe a posição que deseja (linha e coluna) OBS: As coordenas vão de 0 à 2!!: \n");
                        do
                        {
                            Console.Write("Linha: ");
                            linhaj1 = int.Parse(Console.ReadLine());
                            if (linhaj1 != 0 && linhaj1 != 1 && linhaj1 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }
                        } while (linhaj1 != 0 && linhaj1 != 1 && linhaj1 != 2);

                        do
                        {
                            Console.Write("Coluna: ");
                            colunaj1 = int.Parse(Console.ReadLine());
                            if (colunaj1 != 0 && colunaj1 != 1 && colunaj1 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }

                        } while (colunaj1 != 0 && colunaj1 != 1 && colunaj1 != 2);
                        podecolocarpeca = posicao_disponivel(tabuleiro, linhaj1, colunaj1);

                    } while (podecolocarpeca == false);
                    {
                        tabuleiro[linhaj1, colunaj1] = 'X';
                        imprimir_Jogo(tabuleiro);
                        resultadodojogo = verifica_Status(tabuleiro);
                    }
                

                if(verifica_Status(tabuleiro) != '1' && verifica_Status(tabuleiro) != '0')
                {
                    do
                    {
                        Console.WriteLine(nomejog2 + ", informe a posição que deseja (linha e coluna): ");
                        do
                        {
                            Console.Write("Linha: ");
                            linhaj2 = int.Parse(Console.ReadLine());
                            if (linhaj2 != 0 && linhaj2 != 1 && linhaj2 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }
                        } while (linhaj2 != 0 && linhaj2 != 1 && linhaj2 != 2);

                        do
                        {
                            Console.Write("Coluna: ");
                            colunaj2 = int.Parse(Console.ReadLine());
                            if (colunaj2 != 0 && colunaj2 != 1 && colunaj2 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }
                        } while (colunaj2 != 0 && colunaj2 != 1 && colunaj2 != 2);
                        podecolocarpeca = posicao_disponivel(tabuleiro, linhaj2, colunaj2);
                    } while (podecolocarpeca == false);
                    {
                        tabuleiro[linhaj2, colunaj2] = 'O';
                        imprimir_Jogo(tabuleiro);
                        resultadodojogo = verifica_Status(tabuleiro);
                    }
                }
                
            } while (verifica_Status(tabuleiro) != '1' && verifica_Status(tabuleiro) != '2' && verifica_Status(tabuleiro) != '0'); //jogo finalizado


            if (resultadodojogo == '1')
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n" + nomejog1 + " venceu!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            }
            else if (resultadodojogo == '2')
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n" + nomejog2 + " venceu!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            } else if (resultadodojogo == '0')
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\nO jogo Empatou!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            }
            Console.ReadKey();

        }
        static void imprimir_Jogo(char[,] matriz)
        {
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }


        static bool posicao_disponivel(char[,] matriz, int linha, int coluna)
        {
            if (matriz[linha, coluna] == '-')
            {
                return (true);
            }
            else
            {
                Console.WriteLine("\n=> Posição indisponível, escolha outra coordenada!!!\n");
                return (false);
            }
        }


        static char verifica_Status(char[,] matriz)
        {
            if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2]) 
            {
                return ('1'); 
            }
            else if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0]) 
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
            }else if(matriz[0,0] != '-' && matriz[0,1] != '-' && matriz[0,2] != '-' && matriz[1,0] != '-' && matriz[1,1] != '-' && matriz[1,2] != '-' && matriz[2,0] != '-' && matriz[2,1] != '-' && matriz[2,2] != '-')
            {
                return ('0');
            }
            else
            {
                return ('3');
            }
        }
    }
}
