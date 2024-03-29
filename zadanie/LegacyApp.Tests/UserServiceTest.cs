using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_When_Firstname_Is_Missing()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act - Wykonanie funkcjonalnosci
        var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - Sprawdzenie wyniku
        Assert.False(addResult);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Lastname_Is_Missing()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act - Wykonanie funkcjonalnosci
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - Sprawdzenie wyniku
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Incorrect()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act - Wykonanie funkcjonalnosci
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        // Assert - Sprawdzenie wyniku
        Assert.Equal(false,addResult);
    }
    [Fact]
    public void AddUser_Should_Throw_ArgumentException_When_User_Doesnt_Exist()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act & Assert - Wykonanie funkcjonalnosci
        Assert.Throws<ArgumentException>(() =>
        {
            userService.AddUser("Joe", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 7);
        });
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Client_Is_Underage()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act - Wykonanie funkcjonalnosci
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("2010-03-21"), 1);
        // Assert - Sprawdzenie wyniku
        Assert.False(addResult);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_CreditLimit_Below_500()
    {
        // Arrange - przygotowanie zaleznosci
        var userService = new UserService();
        // Act - Wykonanie funkcjonalnosci
        var addResult = userService.AddUser("John", "Kowalski", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        // Assert - Sprawdzenie wyniku
        Assert.False(addResult);
    }
}