using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;

namespace TestingLab3
{
    [TestClass]
    public class PasswordHashingUtilsTests
    {
        [TestMethod]
        public void GetHash_ExecutionRoute_0_1_2_6_7_NullStringHashTest()
        {
            string password = null;
            Assert.ThrowsException<System.ArgumentNullException>(() => PasswordHasher.GetHash(password));
        }

        [TestMethod]
        public void GetHash_ExecutionRoute_0_1_2_4_5_7_NullStringHashTest()
        {
            string password = "password";
            string hash = PasswordHasher.GetHash(password);

            Assert.IsNotNull(hash);
            Assert.AreNotEqual(hash, password);
        }

        [TestMethod]
        public void GetHash_ExecutionRoute_0_1_2_3_4_5_7_OverflowExceptionCatchingTest()
        {
            string password = "-4";
            int hashLength = 64;
            string hash = PasswordHasher.GetHash(password);

            Assert.IsNotNull(hash);
            Assert.AreEqual(hashLength, hash.Length);
            Assert.AreNotEqual(hash, password);
        }

        [TestMethod]
        public void Init_ExecutionRoute_0_1_2_3_CustomSaltAndCustomAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, "my salt here", 15);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 65521);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_ExecutionRoute_0_1_3_CustomSaltAndDefaultAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, "my salt here", 0);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 0);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_ExecutionRoute_0_2_3_DefaultSaltAndCustomAdlerModeTest()
        {
            string password = "password";
            string hash1 = PasswordHasher.GetHash(password, null, 15);
            string hash2 = PasswordHasher.GetHash(password, "put your soul(or salt) here", 65521);

            Assert.IsNotNull(hash1);
            Assert.IsNotNull(hash2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void Init_ExecutionRoute_0_3_DefaultSaltAndAdlerModeTest()
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
