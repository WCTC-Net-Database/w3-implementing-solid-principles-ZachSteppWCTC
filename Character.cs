using System.Text;
using CharacterConsole;

public class Character
{
    //public string Name
    //{
    //    get { return Name; }
    //    set { Name = value; }
    //}

    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int Hitpoints { get; set; }
    public string[] Equipment { get; set; }
    public Character() { }
    public Character(string name, string myclass, int level, int hitpoints, string[] equipment)
    {
        Name = name;
        Class = myclass;
        Level = level;
        Hitpoints = hitpoints;
        Equipment = equipment;
    }

    
    public static string ToLine(Character character)
    {
        StringBuilder sb = new StringBuilder();
        if (character.Name.Contains(','))
        {
            sb.Append('"' + character.Name + '"');
        }
        else 
        {
            sb.Append(character.Name); 
        }
        sb.Append($",{character.Class},{character.Level.ToString()},{character.Hitpoints.ToString()},{String.Join("|", character.Equipment)}");
        return sb.ToString();
    }
    public static Character CreateCharacter(IInput input, IOutput output)
    {
        output.Write("\nEnter your character's name: ");
        string name = input.ReadLine();

        output.Write("\nEnter your character's class: ");
        string characterClass = input.ReadLine();

        int level;
        while (true)
        {
            try
            {
                output.Write("\nEnter your character's level: ");
                level = Convert.ToInt32(input.ReadLine());
                break;
            }
            catch (FormatException)
            {
                output.WriteLine("Please enter an integer.");
            }
        }

        int health;
        while (true)
        {
            try
            {
                output.Write("\nEnter your character's HP: ");
                health = Convert.ToInt32(input.ReadLine());
                break;
            }
            catch (FormatException)
            {
                output.WriteLine("Please enter an integer.");
            }
        }

        var equipment = new List<String>();
        while (true)
        {
            output.WriteLine("Enter new equipment name. Type 0 to end: ");
            output.Write("> ");
            string equipmentText = input.ReadLine();
            if (equipmentText == "0")
            {
                break;
            }
            else
            {
                equipment.Add(equipmentText);
            }
        }

        output.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

        string[] equipmentArray = equipment.ToArray();

        Character character = new Character { Name = name, Class = characterClass, Level = level, Hitpoints = health, Equipment = equipmentArray };
        return character;
    }
    public static Character[] IncreaseCharacterLevel(Character[] characters, IOutput output)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        Character levelcharacter = characters.Where(c => c.Name == nameToLevelUp).FirstOrDefault();
        if (levelcharacter != null)
        {
            //exceptions don't catch the null and can't add to levelcharacter with ? as described in lesson for adding to level
            //if statement seems to work perfectly though
            levelcharacter.Level += 1;
        }
        else
        {
            output.WriteLine($"{nameToLevelUp} is not a name in the current saved characters.");
        }
        return characters;
    }
}