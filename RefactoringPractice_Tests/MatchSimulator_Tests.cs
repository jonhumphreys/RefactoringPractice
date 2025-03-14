﻿namespace RefactoringPractice_Tests;

using Xunit;
using RefactoringPractice;

[Collection("FileAccessTests")]
public class MatchSimulator_Tests
{
    [Fact]
    public void ConstructorInitializesWrestlerGenerator()
    {
        MatchSimulator simulator = new MatchSimulator();
        Assert.NotNull(simulator.WrestlerGenerator);
    }

    [Fact]
    public void RunMatchSeriesGeneratesFirstWrestler()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.NotNull(firstWrestler);
    }

    [Fact]
    public void RunMatchSeriesGeneratesSecondWrestler()
    {
        MatchSimulator simulator = new MatchSimulator();
        simulator.WrestlerGenerator.GenerateWrestler(); 
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.NotNull(secondWrestler);
    }

    [Fact]
    public void RunMatchSeriesFirstWrestlerHasValidName()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(firstWrestler.Name));
    }

    [Fact]
    public void RunMatchSeriesSecondWrestlerHasValidName()
    {
        MatchSimulator simulator = new MatchSimulator();
        simulator.WrestlerGenerator.GenerateWrestler(); 
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(secondWrestler.Name));
    }

    [Fact]
    public void RunMatchSeriesFirstWrestlerHasValidBreed()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(firstWrestler.Breed));
    }

    [Fact]
    public void RunMatchSeriesSecondWrestlerHasValidBreed()
    {
        MatchSimulator simulator = new MatchSimulator();
        simulator.WrestlerGenerator.GenerateWrestler(); 
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(secondWrestler.Breed));
    }

    [Fact]
    public void RunMatchSeriesFirstWrestlerHasValidMoves()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.NotNull(firstWrestler.Moves);
    }

    [Fact]
    public void RunMatchSeriesSecondWrestlerHasValidMoves()
    {
        MatchSimulator simulator = new MatchSimulator();
        simulator.WrestlerGenerator.GenerateWrestler(); 
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.NotNull(secondWrestler.Moves);
    }

    [Fact]
    public void RunMatchSeriesFirstWrestlerHasFourMoves()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.Equal(4, firstWrestler.Moves.Count);
    }

    [Fact]
    public void RunMatchSeriesSecondWrestlerHasFourMoves()
    {
        MatchSimulator simulator = new MatchSimulator();
        simulator.WrestlerGenerator.GenerateWrestler(); 
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Assert.Equal(4, secondWrestler.Moves.Count);
    }

    [Fact]
    public void RunMatchSeriesAnnouncesWinner()
    {
        // Arrange
        MatchSimulator simulator = new MatchSimulator();

        using StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        using StringReader fakeInput = new StringReader("\n\n\n"); // Simulates pressing Enter 3 times
        Console.SetIn(fakeInput);

        // Act
        simulator.RunMatchSeries();
        string output = consoleOutput.ToString();

        // Assert
        Assert.Contains("Winner of Match", output);
    }
    
    [Fact]
    public void RunMatchSeriesChampionHasValidName()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler champion = (simulator.Random.Next(2) == 0) ? firstWrestler : secondWrestler;

        Assert.False(string.IsNullOrWhiteSpace(champion.Name));
    }

    [Fact]
    public void RunMatchSeriesChampionHasValidBreed()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler champion = (simulator.Random.Next(2) == 0) ? firstWrestler : secondWrestler;

        Assert.False(string.IsNullOrWhiteSpace(champion.Breed));
    }

    [Fact]
    public void RunMatchSeriesChampionHasValidCatchphrase()
    {
        MatchSimulator simulator = new MatchSimulator();
        Wrestler firstWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler secondWrestler = simulator.WrestlerGenerator.GenerateWrestler();
        Wrestler champion = (simulator.Random.Next(2) == 0) ? firstWrestler : secondWrestler;

        Assert.False(string.IsNullOrWhiteSpace(champion.Catchphrase));
    }
}
