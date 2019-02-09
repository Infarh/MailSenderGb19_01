using System;
using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class PasswordServiceTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
             Debug.WriteLine("Инициализация модульного теста", context.TestName);
             //Debug.WriteLineIf(true, "Debug text");
             Debug.Assert(context == null, "context != null");
             Trace.Write("Test");
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

        }

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }


        [TestMethod]
        public void Encrypt_abc_to_bcd()
        {
            // AAA
            // Arrange
            var str = "abc";
            var key = 1;
            var expected_result = "bcd";

            // Act
            var actual_result = PasswordService.Encrypt(str, key);

            // Assert
            Assert.AreEqual(expected_result, actual_result, "Ошибка кодирования текста");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Encrypt_ArgumentNullException()
        {
            string str = null;
            var key = 1;

            PasswordService.Encrypt(str, key);
        }

        [TestMethod]
        public void Decrypt_bcd_to_abc()
        {
            // AAA
            // Arrange
            var str = "bcd";
            var key = 1;
            var expected_result = "abc";

            // Act
            var actual_result = PasswordService.Decrypt(str, key);

            // Assert
            Assert.AreEqual(expected_result, actual_result, "Ошибка декодирования текста");
            //StringAssert // Проверка строковых утверждений
            //CollectionAssert // Проверка утверждений для коллекций объектов
            //AssertFailedException // Исключение, выбрасываемое методами классов Assert, StringAssert, CollectionAssert
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Decrypt_ArgumentNullException()
        {
            string str = null;
            var key = 1;

            PasswordService.Decrypt(str, key);
        }
    }
}
