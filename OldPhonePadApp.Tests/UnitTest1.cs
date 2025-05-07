namespace C__Coding_Challenge.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("4433555 555666096667775553#", "HELLO WORLD")]
    [InlineData("8 88777444666*664#", "TURING")]
    [InlineData("2#", "A")]
    [InlineData("222#", "C")]
    [InlineData("7777#", "S")]
    public void DecodeOldPhonePad_ReturnsExpectedOutput(string input, string expected)
    {
        var result = Program.DecodeOldPhonePad(input);

        Assert.Equal(expected, result);
    }
}