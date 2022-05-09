using Microsoft.AspNetCore.Mvc.Infrastructure;
using MiniProject001.API.Controllers;
using MiniProject001.DAL;
using MiniProject001.DAL.Database.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MiniProject001.TEST
{
    /// <summary>
    /// jeg vil gerne kunne teste API Layer og kun det
    /// DVS. vi kommer ikke til at benytte database mm.
    /// DVS vi kan ikke teste det vi gerne vil...
    /// AAA
    /// ARRANGE - DEFINITION (VARIABLER MM)
    /// ACT     - RESULT (INVOKE VORES METODER MM)
    /// ASSERT  - SAMMENLIGNE 2 VÆRDIER
    ///         - RETURNERE JEG DET RIGTIGE OSV...
    
    /// 0) install et xunit project eller bare normal.....
    /// 0) nuget package manager install Moq i test class
    /// 1)oprette objekt af vores Controller
    /// 2)teste en metode i vores Controller - Invoke method
    /// 3)verificer at metoden gør det den skal
    /// </summary>
    public class AuthorsControllerTest
    {
        //System Under Test
        private readonly AuthorsController _sut;
        private readonly Mock<IAuthorRepository> _authorRepo = new(); //??? what the fuck

        public AuthorsControllerTest()
        {
            // _sut = new AuthorsController(normalt vil jeg have IAuthorRepository)
            _sut = new AuthorsController(_authorRepo.Object);
        }

        // decorates a method in xunit
        [Fact]
        public async void getAllAuthors_ShouldReturn200()
        {
            //Arrange - definer variable mm
            List<Author> authorList = new List<Author>
            {
                new Author{AuthorId=1, age=33,isAlive=true,name="Paula",password="Hansi Nissemand"},
                new Author{AuthorId=2, age=11,isAlive=false,name="Kurt",password="mad"},
                new Author{AuthorId=3, age=88,isAlive=true,name="Anna",password="surtKurt"}
            };
            _authorRepo.Setup((IAuthorRepository objOfRepository) => objOfRepository.getAllAuthors())
                .ReturnsAsync(authorList);
            //_authorRepo.Setup(objOfRepository => objOfRepository.getAllAuthors())
            //    .ReturnsAsync(authorList);
            //Act
            //vi får 200 ud
            var result = await _sut.getAllAuthors(); //simulering af invoke method med masser af data
            var status = (IStatusCodeActionResult)result;
            //Assert

            Assert.Equal(200, status.StatusCode);

        }

        [Fact]
        public async void getAllAuthors_ListNotExisting()
        {  
            _authorRepo.Setup(objOfRepository => objOfRepository.getAllAuthors())
                .ReturnsAsync(() => null); // meningen med det tomme lambda er at vi gerne
                                           // vil simulerer at vi ikke får fat i vores database

            //Act
            var result = await _sut.getAllAuthors();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; 
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


    }
}
