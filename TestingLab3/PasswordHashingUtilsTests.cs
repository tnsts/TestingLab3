using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;

namespace TestingLab3
{
    [TestClass]
    public class PasswordHashingUtilsTests
    {
        [TestMethod]
        public void GetHash_1_ExecutionRoute_10_11_12_16_17_NullStringHashTest()
        {
            string password = null;
            Assert.ThrowsException<System.ArgumentNullException>(() => PasswordHasher.GetHash(password));
        }

        [TestMethod]
        public void GetHash_1_ExecutionRoute_10_11_12_14_15_17_NullStringHashTest()
        {
            string password = "password";
            string hash = PasswordHasher.GetHash(password);

            Assert.IsNotNull(hash);
            Assert.AreNotEqual(hash, password);
        }

        [TestMethod]
        public void GetHash_1_ExecutionRoute_10_11_12_13_14_15_17_OverflowExceptionCatchingTest()
        {
            string password1 = "-4";
            string password2 = "進撃の巨人";
            string password3 = "🐂🌹🚒🥰";
            int hashLength = 64;

            string hash1 = PasswordHasher.GetHash(password1);
            string hash2 = PasswordHasher.GetHash(password2);
            string hash3 = PasswordHasher.GetHash(password3);

            Assert.IsNotNull(hash1);
            Assert.AreEqual(hashLength, hash1.Length);
            Assert.AreNotEqual(hash1, password1);

            Assert.IsNotNull(hash2);
            Assert.AreEqual(hashLength, hash2.Length);
            Assert.AreNotEqual(hash2, password2);

            Assert.IsNotNull(hash3);
            Assert.AreEqual(hashLength, hash3.Length);
            Assert.AreNotEqual(hash3, password3);
        }

        [TestMethod]
        public void Init_11_ExecutionRoute_110_111_112_113_CustomSaltAndCustomAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, "my salt here", 15);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 65521);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_11_ExecutionRoute_110_111_113_CustomSaltAndDefaultAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, "my salt here", 0);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 0);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_11_ExecutionRoute_110_112_113_DefaultSaltAndCustomAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, null, 15);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 65521);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_11_ExecutionRoute_110_113_DefaultSaltAndAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, null, 0);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 65521);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreEqual(hash1, hash2);
        }

    }
}
