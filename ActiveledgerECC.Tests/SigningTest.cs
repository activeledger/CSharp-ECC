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

      // Debugging
      // Console.WriteLine("Signature: " + signature);

      Assert.NotNull(signature);
      Assert.NotEqual("", signature);
    }

    [Fact]
    public void TestSignTransaction()
    {
      KeyGenerator keyGen = new KeyGenerator();
      keyGen.GenerateKeyPair();

      String privateKey = keyGen.GetPrivateKey();
      String publicKey = keyGen.GetPublicKey();
      Signer signer = new Signer(privateKey);

      String data = """
        {
          "$namespace": "default",
          "$contract": "onboard",
          "$i": {
            "identity": {
              "type":"secp256k1",
                "publicKey": "PLACEHOLDER"
            }
          }
        }
      """;

      data = data.Replace("PLACEHOLDER", publicKey);

      String signature = signer.Sign(data);

      Assert.NotNull(signature);
      Assert.NotEqual("", signature);

      // Debugging
      /* Console.WriteLine("Transaction:\n" + data);
      Console.WriteLine("\nPrivate Key: " + privateKey);
      Console.WriteLine("\nPublic Key: " + publicKey);
      Console.WriteLine("\nSignature of Transaction: " + signature); */
    }
  }
}
