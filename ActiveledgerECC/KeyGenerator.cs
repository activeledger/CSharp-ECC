namespace ActiveledgerECC
{
  public class KeyGenerator
  {
    private string privateKey = string.Empty;
    private string publicKey = string.Empty;

    public void GenerateKeyPair()
    {
    }

    public string GetPrivateKey()
    {
      return privateKey;
    }

    public string GetPublicKey()
    {
      return publicKey;
    }
  }
}
