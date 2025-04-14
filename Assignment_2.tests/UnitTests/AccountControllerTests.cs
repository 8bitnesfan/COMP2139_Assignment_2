using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Assignment_1.Models;
using Assignment_1.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class AccountControllerTests
{
    private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
    private readonly Mock<SignInManager<ApplicationUser>> _mockSignInManager;
    private readonly AccountController _controller;

    public AccountControllerTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(
            new Mock<IUserStore<ApplicationUser>>().Object, null, null, null, null, null, null, null, null);

        _mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
            _mockUserManager.Object, new Mock<IHttpContextAccessor>().Object, 
            new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object, null, null, null, null);

        _controller = new AccountController(_mockUserManager.Object, _mockSignInManager.Object);
    }

    [Fact]
    public async Task Login_ValidCredentials_ShouldRedirectToHome()
    {
        var model = new LoginViewModel { Email = "test@example.com", Password = "password", RememberMe = true };
        _mockSignInManager.Setup(s => s.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true))
            .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);  

        var result = await _controller.Login(model) as RedirectToActionResult;

        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
        Assert.Equal("Home", result.ControllerName);
    }

    [Fact]
    public async Task Register_ValidUser_ShouldRedirectToHome()
    {
        var model = new RegisterModel { Email = "newuser@example.com", Password = "SecurePass123", FirstName = "John", LastName = "Doe" };
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

        _mockUserManager.Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), model.Password))
            .ReturnsAsync(IdentityResult.Success);
        _mockSignInManager.Setup(s => s.SignInAsync(It.IsAny<ApplicationUser>(), true, null))
            .Returns(Task.CompletedTask);

        var result = await _controller.Register(model) as RedirectToActionResult;

        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
        Assert.Equal("Home", result.ControllerName);
    }
}