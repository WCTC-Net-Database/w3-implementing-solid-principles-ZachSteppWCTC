using CharacterConsole;

public class CharacterReader
{
    public static Character[] ReadLines(string _filepath)
    {
        string[] lines = File.ReadAllLines(_filepath);
        Character[] result = new Character[lines.Length-1];
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            string fields;

            // Check if the name is quoted
            if (line.StartsWith('"'))
            {

                var firstQuotePos = lines[i].IndexOf('"');
                name = lines[i].Substring(firstQuotePos + 1);
                var lastQuotePos = name.IndexOf('"');

                name = name.Substring(firstQuotePos, lastQuotePos - firstQuotePos);
                fields = line.Substring(lastQuotePos + 1);
            }
            else
            {
                name = lines[i].Split(",")[0];
                int firstComma = line.IndexOf(",");
                fields = line.Substring(firstComma);
            }
            string Class = fields.Split(",")[1];
            int level = Int32.Parse(fields.Split(",")[2]);
            int hp = Int32.Parse(fields.Split(",")[3]);
            string equipmentLine = fields.Split(",")[4];
            string[] equipment = equipmentLine.Split('|');

            result[i-1] = new Character { Name = name, Class = Class, Level = level, Hitpoints = hp, Equipment = equipment };
        }
        return result;
    }

    public static void PrintCharacters(Character[] characters, IOutput _output)
    {
        foreach (Character character in characters)
        {
            _output.WriteLine("\n--------------------------------------------\n");
            _output.WriteLine($"Name: {character.Name}");
            _output.WriteLine($"Class: {character.Class}");
            _output.WriteLine($"Level: {(character.Level).ToString()}");
            _output.WriteLine($"HP: {(character.Hitpoints).ToString()}");
            _output.WriteLine("Eqiquipment:");
            string[] equipment = character.Equipment;
            for (int j = 0; j < equipment.Length; j++)
            {
                _output.WriteLine($" - {equipment[j]}");
            }
        }
        _output.WriteLine("\n--------------------------------------------\n");
    }
}