using Lab16_WebAPI.Controllers;
using Lab16_WebAPI.Model;
using Lab16_WebAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Moq;

namespace Lab_TestApp
{
  [TestClass]
  public class ContactControllerTest
  {
    private Mock<IContactService> _contactService;
    private ContactController _contactController;

    [TestInitialize]
    public void Initialaze()
    {
      _contactService = new Mock<IContactService>();
      _contactController = new ContactController(_contactService.Object);
    }

    [TestMethod]
    public void GetAllContact_PositiveTesting_ShouldCompleteSuccessfully()
    {
      //var contServiceMoq = new Mock<IContactService>();

      _contactService.Setup(x => x.GetAllContacts()).Returns(new List<Contact>() { new Contact() });

      //var contactController = new ContactController(_contactService.Object);

      var res = _contactController.Get();

      Assert.AreNotEqual(res.Count(), 0);
    }

    [TestMethod]
    public void GetContact_PositiveTesting_ShouldCompleteSuccessfully()
    {
      var id = new Guid();
      _contactService.Setup(x => x.GetContact(id)).Returns(new Contact());      

      var res = _contactController.GetContact(id);

      Assert.IsNotNull(res);
    }

    [TestMethod]
    public void GetContact_NegativTesting_ShouldCompleteSuccessfully()
    {
      var id = new Guid();
      _contactService.Setup(x => x.GetContact(id)).Returns();

      var res = _contactController.GetContact(id);      
    }
  }
