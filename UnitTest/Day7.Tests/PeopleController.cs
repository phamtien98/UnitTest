using NUnit.Framework;
using Day7.Controllers;
using Day7.Services;
using Moq;
using Day7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day7.Tests;

public class PeopleController
{
    private MemberController _controller;
    private Mock<IMemberService> mockRepo;
    private List<MembeModel> InitstListAllMember()
    {
        return new List<MembeModel>()
        {
            new MembeModel () {id=1, FirstName = "Tien111"},
            new MembeModel () {id=2, FirstName = "Nam"},
        };
    }
    [SetUp]
    public void Setup()
    {
        mockRepo = new Mock<IMemberService>();
        _controller = new MemberController(mockRepo.Object);

    }

    [Test]
    public void Index_ReturnViewAllPeoPle()
    {
        //Arrange
        mockRepo.Setup(m => m.GetAllPeople()).Returns(InitstListAllMember);

        //Act
        var result = _controller.Index();
        var temp = (result as ViewResult).Model as List<MembeModel>;

        //Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.AreEqual(2, temp.Count);
    }

    [Test]
    public void Edit_ReturnViewEdited()
    {

        //Arrange
        var list = InitstListAllMember;
        mockRepo.Setup(m => m.GetAllPeople()).Returns(InitstListAllMember);
        //Act
        MembeModel member = new MembeModel() { id = 1, FirstName = "Edited" };
        var result = _controller.UpdatePeople(member);
        var results = _controller.Index();
        var checkRS = _controller.GetMemberById(1);
        var temp = (results as ViewResult).Model as List<MembeModel>;

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }

    [Test]
    public void Delete_ReturnView()
    {
        //Arrange
        mockRepo.Setup(m => m.GetAllPeople()).Returns(InitstListAllMember);
        MembeModel member = new MembeModel() { id = 2, FirstName = "member 3" };

        //Act
        var DeleteResult = _controller.DeletePeople(2);
        var members = _controller.Index();
        var temp = (members as ViewResult).Model as List<MembeModel>;

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(DeleteResult);
    }

    [Test]
    public void Add_ReturnView()
    {
        // Arrange
        MembeModel member = new MembeModel() { id = 3, FirstName = "member 3" };
        mockRepo.Setup(m => m.GetAllPeople()).Returns(InitstListAllMember);
        mockRepo.Setup(m => m.CreateMember(member));

        // Act
        var add = _controller.CreatePeople(member);
        var result = _controller.Index();
        var temmp = (result as ViewResult).Model as List<MembeModel>;

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(add);
    }
}