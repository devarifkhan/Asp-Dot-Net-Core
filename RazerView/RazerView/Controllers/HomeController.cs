using Microsoft.AspNetCore.Mvc;
using RazerView.Models;
using System;

namespace RazerView.Controllers
{
    public class HomeController : Controller
    {

        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.net Core Razer View App";
            List<Person> people = new List<Person>()
            {
                new Person()
    {Name="Ariful islam",
    DateOfBirth=DateTime.Parse("2000-04-26"),
    PersonGender=Person.Gender.Male
    },
   new Person() {Name="Linda",
    DateOfBirth=DateTime.Parse("1998-07-24"),
    PersonGender=Person.Gender.Male
    },
    new Person()
    {
        Name="john",
    DateOfBirth=DateTime.Parse("2008-03-13"),
    PersonGender=Person.Gender.Male
    }

    };


            return View("Index", people);// Views/Home/Index.cshtml
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null) return Content("Person name can't be null");
            List<Person> people = new List<Person>()
            {
                new Person()
                {Name="Ariful islam",
                DateOfBirth=DateTime.Parse("2000-04-26"),
                PersonGender=Person.Gender.Male
                },
               new Person() {Name="Linda",
                DateOfBirth=DateTime.Parse("1998-07-24"),
                PersonGender=Person.Gender.Male
                },
                new Person()
                {
                    Name="john",
                DateOfBirth=DateTime.Parse("2008-03-13"),
                PersonGender=Person.Gender.Male
            }
            };

            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson);  //Views/Home/Details.cshtml

        }
        [Route("person-with-product")]

        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "Sara",
                DateOfBirth = DateTime.Parse("2000-04-26"),
                PersonGender = Person.Gender.Male
            };
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Gaming PC"
            };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product,
            };

            return View(personAndProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
        }
    }
}

