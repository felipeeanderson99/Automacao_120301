using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;

namespace Automacao_120301
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.leomadeiras.com.br/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(4500);
        }

        [Test]
        public void ComprarProduto()
        {

            PageObject page = new PageObject(driver);

            page.aguardarCarregamentoDaTela();
            page.clickMenuTodasCategorias();
            page.MenuCompensados();

            page.ComprandoProduto();
            page.adicionandoAoCarrinho();
            page.cep();
            page.validandoPedido();

        }

        [TearDown]
        public void Dispose()
        {
            driver.Quit();
        }
    }
}