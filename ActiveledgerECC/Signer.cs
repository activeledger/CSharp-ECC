namespace ActiveledgerECC
{
  public class Signer
  {
    private string privateKey;

    public Signer(String privateKey)
    {
      this.privateKey = privateKey;
    }

    public string Sign(String data)
    {
      // Convert.ToBase64String(signature)
      return string.Empty;
    }

    public bool Verify(string data, string signature)
    {
      return false;
    }
  }
}
