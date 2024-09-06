using System.Reflection.Emit;
using System.Security.Claims;
using System.Xml.Linq;
using CharacterConsole;

public class CharacterWriter
{
    public static void WriteFile(Character[] characters, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("Name, Class, Level, HP, Equipment");
            for (int i = 0; i < characters.Length; i++)
            {
                string line = Character.ToLine(characters[i]);
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }
}