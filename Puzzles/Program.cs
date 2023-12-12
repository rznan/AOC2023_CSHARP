﻿using Puzzles;
using System.IO;

Console.Clear();
Console.WriteLine("\n-----ADVENT OF CODE 2023-----\n");
while (true)
{
    Console.Write
    (
        "Selecione um dia: [99 - sair]\n" +
        ">>> "
    );
    if(int.TryParse(Console.ReadLine(), out int opcao))
    {
        string[] input;
        switch(opcao)
        {
            case 1:
                input = File.ReadAllLines(".\\Day01.csv");
                Console.WriteLine("Dia 1 - Trebutchet");
                Console.WriteLine($"\tParte 1: \t{Day01.Part1Solution(input)}");
                Console.WriteLine($"\tParte 2: \t{Day01.Part2Solution(input)}");
                break;

            case 2:
                input = File.ReadAllLines(".\\Day02.txt");
                Console.WriteLine("Day 2: Cube Conundrum");
                Console.WriteLine($"\tParte 1: \t{Day02.Part1Solution(input)}");
                Console.WriteLine($"\tParte 2: \t{Day02.Part2Solution(input)}");
                break;

            case 3:
                input = File.ReadAllLines(".\\Day03.txt");
                Console.WriteLine("Day 3: Gear Ratios");
                Console.WriteLine($"\tParte 1: \t{Day03.Part1Solution(input)}");
                Console.WriteLine($"\tParte 2: \t{Day03.Part2Solution(input)}");
                break;

            case 99: 
                System.Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Não foi possível encontrar o dia");
                break;
        }
    }
    else
        Console.WriteLine("Não foi possível processar o número");
    Console.WriteLine("\n-----------------------------\n");
}