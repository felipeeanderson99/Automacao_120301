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
        public void CompraProduto()
        {

            PageObject page = new PageObject();

            page.aguardarCarregamentoDaTela(driver);
            page.clickMenuTodasCategorias(driver);
            page.MenuCompensados(driver);
            page.ComprandoProduto(driver);
            page.adicionandoAoCarrinho(driver);
            page.cep(driver);
            page.validandoPedido(driver);

        }

        [TearDown]
        public void Dispose()
        {
            driver.Quit();
        }
    }
}