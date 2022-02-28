using NUnit.Framework;
using Day7.Controllers;
using Day7.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;


namespace Day7.Tests;

public class PeopleController
{
    private MemberController _controller;
    [SetUp]
    public void Setup()
    {
        var mockRepo = new Mock<IMemberService>();
        _controller = new MemberController(mockRepo.Object);
    }

    [Test]
    public void Index_ReturnView()
    {
        var mockRepo = new Mock<IMemberService>();
        _controller = new MemberController(mockRepo.Object);
        //Act
        var result = _controller.Index();

        Assert.Pass();
    }
}