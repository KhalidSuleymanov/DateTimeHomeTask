
using System;
using System.Text.RegularExpressions;

namespace DateTimeHomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            string opr;
            do
            {
                Console.WriteLine("1. Enter Group");
                Console.WriteLine("2. Look at the groups");
                Console.WriteLine("3. Look at the groups according to the type value");
                Console.WriteLine("4: See groups started so far");
                Console.WriteLine("5: See groups started in the last 2 months");
                Console.WriteLine("6: Check out the new groups starting by the end of this month");
                Console.WriteLine("7: View groups that started within 2 given dates");
                Console.WriteLine("0. Out menu");
                Console.WriteLine("Please select an operation");
                opr = Console.ReadLine();
                switch (opr)
                {
                    case "1":
                        Console.Write("No:  ");
                        string No = Console.ReadLine();
                        Console.Write("Type:  ");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        Console.WriteLine($"{(byte)item} - {item}");

                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;
                        Console.Write("StartDate:  ");
                        string Datestr = Console.ReadLine();
                        DateTime StartDate = Convert.ToDateTime(Datestr);

                        Group group = new Group
                        {
                            No = No,
                            Type = type,
                            StartDate = StartDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":


                        foreach (var Group in groups)
                        {
                            Console.WriteLine($"No: {Group.No} - Type: {Group.Type} - StartDate: {Group.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;
                        foreach (var grp in groups)
                        {
                            if (grp.Type == type)
                            {
                                Console.WriteLine($"No: {grp.No} - Type: {grp.Type}  - StartDate:  {grp.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            } 
                        }
                        break;
                    case "4":
                        int count = 0;
                        foreach (var gro in groups)
                        {
                            if (gro.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {gro.No} - Type: {gro.Type}  - StartDate:  {gro.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("There is no such group");
                        }
                        break;
                    case "5":
                        int count1 = 0;
                        foreach (var grop in groups)
                        {
                            if (grop.StartDate > DateTime.Now.AddMonths(-2) && grop.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {grop.No} - Type: {grop.Type}  - StartDate:  {grop.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count1++;
                            }
                        }
                        if (count1 == 0)
                        {
                            Console.WriteLine("There is no such group");
                        }
                        break;
                    case "6":
                        int count2 = 0;
                        foreach (var grop in groups)
                        {
                            if(grop.StartDate.Year >= DateTime.Now.Year && grop.StartDate.Month >= DateTime.Now.Month && grop.StartDate.Day >= DateTime.Now.Day)
                            {
                                Console.WriteLine($"No: {grop.No} - Type: {grop.Type}  - StartDate:  {grop.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count2++;
                            }
                        }
                        if(count2 == 0)
                        {
                            Console.WriteLine("There is no such group");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Enter the first date");
                        string firstDate = Console.ReadLine();
                        DateTime FirstDate = Convert.ToDateTime(firstDate);

                        Console.WriteLine("Enter the second date");
                        string secondDate = Console.ReadLine();
                        DateTime SecondDate = Convert.ToDateTime(secondDate);
                        int count3 = 0;
                        foreach (var group1 in groups)
                        {
                            if(group1.StartDate >= FirstDate && group1.StartDate <= SecondDate)
                            {
                                Console.WriteLine($"No: {group1.No} - Type: {group1.Type}  - StartDate:  {group1.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count3++;
                            }
                        }
                        if(count3 == 0)
                        {
                            Console.WriteLine("There is no such group");
                        }
                        break;

                    case "0":
                        Console.WriteLine("The program is over");
                        break;
                    default:
                        Console.WriteLine("Your selection is incorrect");
                        break;
                }

            } while (opr != "0");
        }
    }
}
