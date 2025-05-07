using System.Text;

namespace C__Coding_Challenge;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("Old Phone Pad Decoder");
        Console.WriteLine("Enter sequences like '4433555 555666#'. Type 'exit' to quit.\n");

        while (true)
        {
            Console.Write("Enter input sequence: ");
            var input = Console.ReadLine()?.Trim();

            // Check for empty input
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty.\n");
                continue;
            }

            // Exit condition
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Ensure the input ends with '#'
            if (!input.EndsWith("#"))
            {
                Console.WriteLine("Input must end with '#'. Try again.\n");
                continue;
            }

            // Decode and display the result
            Console.WriteLine("Output: " + DecodeOldPhonePad(input) + "\n");
        }
    }

    /// <summary>
    ///     Translates a numeric keypad sequence into corresponding text.
    ///     Supports old mobile keypad layout with space (pause), backspace '*', and end marker '#'.
    /// </summary>
    public static string DecodeOldPhonePad(string input)
    {
        // Mapping of keypad numbers to corresponding letters
        var keypad = new Dictionary<char, string>
        {
            { '1', "" }, { '2', "ABC" }, { '3', "DEF" },
            { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
            { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" },
            { '0', " " }
        };

        var output = new StringBuilder();
        var group = new StringBuilder();

        foreach (var c in input)
            switch (c)
            {
                case '#':
                    // End of input: process any remaining group
                    AppendGroup(output, group, keypad);
                    return output.ToString();

                case '*':
                    // Backspace: process current group and remove last character from output
                    AppendGroup(output, group, keypad);
                    if (output.Length > 0) output.Length--;
                    break;

                case ' ':
                    // Space separates different character groups
                    AppendGroup(output, group, keypad);
                    break;

                default:
                    if (char.IsDigit(c))
                    {
                        // Start a new group if digit changes
                        if (group.Length > 0 && group[0] != c) AppendGroup(output, group, keypad);
                        group.Append(c);
                    }

                    break;
            }

        return output.ToString();
    }

    /// <summary>
    ///     Converts a sequence of repeated digit presses into a single character.
    /// </summary>
    private static void AppendGroup(StringBuilder output, StringBuilder group, Dictionary<char, string> keypad)
    {
        if (group.Length == 0) return;

        var key = group[0];
        if (keypad.TryGetValue(key, out var letters) && letters.Length > 0)
        {
            var index = (group.Length - 1) % letters.Length;
            output.Append(letters[index]);
        }

        group.Clear(); // Reset the group after processing
    }
}