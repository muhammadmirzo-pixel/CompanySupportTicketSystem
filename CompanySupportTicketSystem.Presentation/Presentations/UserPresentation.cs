using static System.Console;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Users;
using CompanySupportTicketSystem.Service.Services;
using CompanySupportTicketSystem.Service.Exceptions;
namespace CompanySupportTicketSystem.Presentation.Presentations;

public class UserPresentation
{
    public static async Task Show()
    {
        UserService userService = new UserService();
        bool check = true;
        while (check)
        {
            try
            {
                await Out.WriteLineAsync("1. Register new User");
                await Out.WriteLineAsync("2. Delete User by Id");
                await Out.WriteLineAsync("3. Update User");
                await Out.WriteLineAsync("4. Get by Id");
                await Out.WriteLineAsync("5. Get all");
                await Out.WriteLineAsync("6. Close");

                int number = int.Parse(ReadLine());
                User user = new User();
                switch (number)
                {
                    case 1:
                        Clear();
                        await Out.WriteAsync("Enter the FirstName: ");
                        user.FirstName = ReadLine();

                        await Out.WriteAsync("Enter the LastName: ");
                        user.LastName = ReadLine();

                        await Out.WriteAsync("Enter the Email ");
                        user.Email = ReadLine();

                        await Out.WriteAsync("Enter the Password: ");
                        user.Password = ReadLine();

                        await Out.WriteAsync("Enter the Phone number: ");
                        user.PhoneNumber = ReadLine();

                        await Out.WriteAsync("Please enter your date of birth (dd-MM-yyyy): ");
                        user.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                        await Out.WriteAsync("Enter the Address: ");
                        user.Address = ReadLine();

                        await Out.WriteAsync("Enter the Gender(man/woman): ");
                        user.Gender = ReadLine();
                        if (user.Gender == "man")
                            await Out.WriteLineAsync();
                        else if (user.Gender == "woman")
                            await Out.WriteLineAsync();
                        else
                            await Out.WriteLineAsync("We only serve individuals who identify as male or female!");
                    break;



                    case 2:
                        Clear();
                        await Out.WriteAsync("Enter the UserId -> ");
                        int userId = int.Parse(ReadLine());

                        var deleteUser = await userService.DeleteByIdAsync(userId);
                        if (deleteUser)
                            await Out.WriteLineAsync("User successfully deleted");
                    break;



                    case 3:
                        Clear();
                        await Out.WriteAsync("Enter the User ID: ");
                        int Id = int.Parse(ReadLine());
                        UserForUpdateDto userUpd = new UserForUpdateDto();

                        await Out.WriteAsync("FirstName: ");
                        userUpd.FirstName = ReadLine();

                        await Out.WriteAsync("LastName: ");
                        userUpd.LastName = ReadLine();

                        await Out.WriteAsync("Email: ");
                        userUpd.Email = ReadLine();

                        await Out.WriteAsync("Phone number: ");
                        userUpd.PhoneNumber = ReadLine();

                        await Out.WriteAsync("Date of birth\n(dd-MM-yyyy): ");
                        user.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                        await Out.WriteAsync("Adress: ");

                        Write("Enter the Gender(man/woman): ");
                        userUpd.Gender = ReadLine();
                        if (userUpd.Gender == "man")
                            await Out.WriteLineAsync();
                        else if (userUpd.Gender == "woman")
                            await Out.WriteLineAsync();
                        else
                            await Out.WriteLineAsync("We only serve individuals who identify as male or female!");
                    break;



                    case 4:
                        Clear();
                        await Out.WriteAsync("Enter the User ID: ");
                        long UserId = long.Parse(ReadLine());
                        var userInfo = await userService.GetByIdAsync(UserId);

                        await Out.WriteAsync($"Firstname: {userInfo.FirstName}" +
                            $"\nLastname: {userInfo.LastName}" +
                            $"\nEmail: {userInfo.Email}" +
                            $"\nPhone number: {userInfo.PhoneNumber}" +
                            $"\nDate of birth: {userInfo.Gender}");
                    break;



                    case 5:
                        Clear();
                        var UserInfo = await userService.GetAllAsync();
                        foreach (var userInformation in UserInfo)
                            await Out.WriteAsync($"Firstname: {userInformation.FirstName}" +
                                $"\nLastname: {userInformation.LastName}" +
                                $"\nEmail: {userInformation.Email}" +
                                $"\nPhone number: {userInformation.PhoneNumber}" +
                                $"\nGender: {userInformation.Gender}");
                    break;



                    case 6:
                        Console.Clear();
                        await Out.WriteLineAsync("Thank you :)");
                        check = false;
                    break;
                }
            }
            catch (TicketExceptions ex)
            {
                await Out.WriteLineAsync($"{ex.statusCode} : {ex.Message}");
            }
            catch (Exception ex)
            {
                await Out.WriteLineAsync(ex.Message);
            }
            finally
            {
                await Out.WriteLineAsync() ;
            }
        }
    }
}
