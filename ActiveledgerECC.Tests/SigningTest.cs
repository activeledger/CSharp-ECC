namespace ActiveledgerECC.Tests
{
    public class SigningTest
    {
        [Fact]
        public void SignData()
        {
            KeyGenerator keyGen = new KeyGenerator();
            keyGen.GenerateKeyPair();

            String privateKey = keyGen.GetPrivateKey();
            Signer signer = new Signer(privateKey);
            String data = "{\"test\": \"data\"}";

            String signature = signer.Sign(data);

            Console.WriteLine("Signature: " + signature);

            Assert.NotNull(signature);
            Assert.NotEqual("", signature);
        }
    }
}
