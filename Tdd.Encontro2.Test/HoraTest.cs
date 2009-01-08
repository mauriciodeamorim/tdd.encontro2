using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tdd.Encontro2;

namespace Tdd.Encontro2.Test
{
    /// <summary>
    /// Summary description for HoraTest
    /// </summary>
    [TestClass]
    public class HoraTest
    {
        public HoraTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Criacao_Hora_Informando_Hora_E_Minuto()
        {
            Hora hora = new Hora("10:30");

            Assert.AreEqual<string>("10:30", hora.ToString());
        }

        [TestMethod]
        public void Criacao_Hora_Nao_Informando_Hora_E_Minuto()
        {
            Hora hora = new Hora();

            Assert.AreEqual<string>("00:00", hora.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Criacao_Hora_Formato_Invalido_Excecao_Esperada()
        {
            Hora hora = new Hora("00-00");
        }

        [TestMethod]
        public void Criacao_Hora_Formato_Invalido()
        {
            try
            {
                Hora hora = new Hora("00-00");
                Assert.Fail("O formato '00-00' é inválido. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: 00-00", e.Message);
            }
        }

        [TestMethod]
        public void Criacao_Hora_Com_Um_Digito()
        {
            Hora hora = new Hora("9:30");

            Assert.AreEqual<string>("9:30", hora.ToString());
        }

        [TestMethod]
        public void Criacao_Hora_Com_Mais_De_Dois_Digitos()
        {
            Hora hora = new Hora("130:00");

            Assert.AreEqual<string>("130:00", hora.ToString());
        }

        [TestMethod]
        public void Criacao_Hora_Sem_Digito_De_Horas()
        {
            try
            {
                Hora hora = new Hora(":15");
                Assert.Fail("Uma hora não pode ser criada só com minutos. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: :15", e.Message);
            }
        }

        [TestMethod]
        public void Criacao_Hora_Negativa()
        {
            Hora hora = new Hora("-1:00");

            Assert.AreEqual<string>("-1:00", hora.ToString());
        }

        [TestMethod]
        public void Criacao_Hora_Com_Minutos_Invalidos()
        { 
            try
            {
                Hora hora = new Hora("5:60");
                Assert.Fail("Os minutos de '5:60' são inválidos. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: 5:60", e.Message);
            }
        }

        [TestMethod]
        public void Soma_Horas_Com_Um_Digito()
        {
            Hora hora = new Hora("3:00");
            hora.SomaHoras("5:00");

            Assert.AreEqual<string>("8:00", hora.ToString());
        }

        [TestMethod]
        public void Soma_Horas_Com_Mais_De_Um_Digito()
        {
            Hora hora = new Hora("1234:00");
            hora.SomaHoras("6:00");

            Assert.AreEqual<string>("1240:00", hora.ToString());        
        }

        [TestMethod]
        public void Soma_Horas_Com_Valor_Negativo()
        {
            Hora hora = new Hora("333:00");
            hora.SomaHoras("-3:00");

            Assert.AreEqual<string>("330:00", hora.ToString());
        }

        [TestMethod]
        public void Soma_Horas_Com_Minutos()
        {
            Hora hora = new Hora("1:10");
            hora.SomaHoras("2:15");

            Assert.AreEqual<string>("3:25", hora.ToString());
        }

        [TestMethod]
        public void Soma_Horas_Formato_Invalido()
        {
            try
            {
                Hora hora = new Hora("1:10");
                hora.SomaHoras("2-15");

                Assert.Fail("O formato '2-15' é inválido. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: 2-15", e.Message);
            }
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Informando_Hora_E_Minuto()
        {
            Hora_Accessor hora = new Hora_Accessor();
            hora.ValidarHora("10:30");
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Formato_Invalido()
        {
            try
            {
                Hora_Accessor hora = new Hora_Accessor();
                hora.ValidarHora("00-00");

                Assert.Fail("O formato '00-00' é inválido. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: 00-00", e.Message);
            }
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Com_Um_Digito()
        {
            Hora_Accessor hora = new Hora_Accessor();
            hora.ValidarHora("9:30");
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Com_Mais_De_Dois_Digitos()
        {
            Hora_Accessor hora = new Hora_Accessor();
            hora.ValidarHora("130:00");
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Sem_Digito_De_Hora_Accessors()
        {
            try
            {
                Hora_Accessor hora = new Hora_Accessor();
                hora.ValidarHora(":15");

                Assert.Fail("Uma hora não pode ser criada só com minutos. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: :15", e.Message);
            }
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Negativa()
        {
            Hora_Accessor hora = new Hora_Accessor();
            hora.ValidarHora("-1:00");
        }

        [TestMethod]
        [DeploymentItem("Tdd.Encontro2.dll")]
        public void Validar_Hora_Accessor_Com_Minutos_Invalidos()
        {
            try
            {
                Hora_Accessor hora = new Hora_Accessor();
                hora.ValidarHora("5:60");

                Assert.Fail("Os minutos de '5:60' são inválidos. Uma ArgumentException deveria ser lançada.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual<string>("Formato de Hora inválido: 5:60", e.Message);
            }
        }

        //TODO: Next step - To add one hour in Hora when the minutes are greaters that 59
        //[TestMethod]
        //public void Soma_Horas_Com_Minutos_Acima_De_59_Minutos()
        //{
        //    Hora hora = new Hora("1:50");
        //    hora.SomaHoras("2:30");

        //    Assert.AreEqual<string>("4:20", hora.ToString());
        //}
        //TODO: Criar testes de ValidarHora passando nulo e "vazio".
    }
}
