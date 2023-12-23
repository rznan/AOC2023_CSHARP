using Puzzles;
namespace PuzzlesTests;

public class Day01Tests
{
    [Fact]
    public void Part1Solution_Pass_NonNumberStringArray_ReturnsZero()
    {
        // arrange
        string[] EmptyStringArray = ["aaaaaaaaaa"];

        // Act
        int result = Day01.Part1Solution(EmptyStringArray);
        
        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Part1Solution_Pass_SingleNumber1InStringArray_returns11()
    {
        // arrange
        string[][] arrays = 
        [
            ["1aaaaaaaaa"],
            ["aaaa1aaaaa"],
            ["aaaaaaaaa1"]
        ];

        // Act / Assert
        Assert.All(arrays,
                   arr => Assert.Equal(11, Day01.Part1Solution(arr)));
    }

    [Fact]
    public void Part2Solution_Pass_StringtwoneInStringArray_Returns21()
    {
        // arrange
        string[] strings = ["twone"];

        // Act
        int result = Day01.Part2Solution(strings);

        // Assert
        Assert.Equal(21, result);
    }
}