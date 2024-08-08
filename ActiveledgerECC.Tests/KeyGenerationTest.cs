namespace ActiveledgerECC.Tests
{
  public class KeyGenerationTest
  {
    [Fact]
    public void GenerateKeys()
    {
      KeyGenerator keyGen = new KeyGenerator();
      keyGen.GenerateKeyPair();

      Assert.True(keyGen.GetPrivateKey() != null);
      Assert.True(keyGen.GetPublicKey() != null);

      Console.WriteLine("Private Key: " + keyGen.GetPrivateKey());
      Console.WriteLine("Public Key: " + keyGen.GetPublicKey());
    }
  }
}
