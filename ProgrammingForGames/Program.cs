using System;
using System.Collections.Generic;

namespace DevelopmentTeamConsoleApp
{
    enum Skillset { Programmer, Designer, Artist, Audio }

    class TeamMember /// Within this class we have all infomation required and set for this questionaire.
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsOver18 { get; set; }
        public Skillset Skillset { get; set; }
        public bool IsAvailableInPerson { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int teamMembersCount = 0;
            const int requiredMembers = 3;
            List<TeamMember> teamMembers = new List<TeamMember>();

            do
            {
                Console.WriteLine("Please enter information for team member #" + (teamMembersCount + 1) + ":");

                string name = GetInput("Name: ");
                int age = GetIntInput("Age: ");

                if (age < 18)
                {
                    Console.WriteLine("This person is underage. Please enter someone else.");
                    continue; // Skip adding this member and restart the loop
                }

                Skillset skillset = GetSkillsetInput();

                bool isAvailableInPerson = GetYesNoInput("Are they available to work in person? (Y/N): ");


                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(); // Blank Lines to Create Space for ease of reading
                Console.WriteLine(); // Blank Lines to Create Space for ease of reading
                Console.WriteLine("Review the information:");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Age: " + age);
                Console.WriteLine("Over 18: Yes"); // Age is checked above
                Console.WriteLine("Skillset: " + skillset);
                Console.WriteLine("Available in person: " + (isAvailableInPerson ? "Yes" : "No"));
                Console.WriteLine(); // Blank Lines to Create Space for ease of reading 
                Console.WriteLine(); // Blank Lines to Create Space for ease of reading

                bool isCorrect = GetYesNoInput("Is this information correct? (Y/N): ");
                if (isCorrect)
                {
                    // Data is correct, create a TeamMember object and add it to the list
                    TeamMember member = new TeamMember
                    {
                        Name = name,
                        Age = age,
                        IsOver18 = true, // Since age is checked, set IsOver18 to true
                        Skillset = skillset,
                        IsAvailableInPerson = isAvailableInPerson
                    };
                    teamMembers.Add(member);

                    // Increment team member count
                    teamMembersCount++;
                }

            } while (teamMembersCount < requiredMembers);
           
            Console.WriteLine(); // Blank Lines to Create Space for ease of reading
            Console.WriteLine("Thank you for providing the information for your development team!");
            Console.WriteLine("Here is the summary of your team members:");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(); // Blank Lines to Create Space for ease of reading

            foreach (var member in teamMembers)
            {
                Console.WriteLine($"Name: {member.Name}");
                Console.WriteLine($"Age: {member.Age}");
                Console.WriteLine($"Over 18: {member.IsOver18}");
                Console.WriteLine($"Skillset: {member.Skillset}");
                Console.WriteLine($"Available in person: {member.IsAvailableInPerson}");
                Console.WriteLine(); // Blank Lines to Create Space for ease of reading 
            }

            Console.WriteLine("Your team is ready!");
        }


        // Helper methods for getting user input 01OCT23 (updated with error notifications 02OCT23)
        static string GetInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        static int GetIntInput(string prompt)
        {
            int result;
            while (!int.TryParse(GetInput(prompt), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return result;
        }

        static Skillset GetSkillsetInput() /// added to make sure only the chosen skillSets are chosen
        {
            Console.WriteLine("Skillset options:");
            foreach (Skillset value in Enum.GetValues(typeof(Skillset)))
            {
                Console.WriteLine($"{(int)value}: {value}");
            }

            int skillsetValue;
            while (!Enum.IsDefined(typeof(Skillset), (skillsetValue = GetIntInput("Enter the corresponding number for the skillset: "))))
            {
                Console.WriteLine("Invalid input. Please enter a valid skillset number.");
            }

            return (Skillset)skillsetValue;
        }

        static bool GetYesNoInput(string prompt) /// added to clearly state options in Y/N situations
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim().ToUpper();
                if (input != "Y" && input != "N")
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            } while (input != "Y" && input != "N");

            return input == "Y";
        }
    }
}
