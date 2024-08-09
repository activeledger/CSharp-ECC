using Org.BouncyCastle.Crypto.Parameters;
// using Org.BouncyCastle.Crypto.Signers;

using Org.BouncyCastle.Asn1.Sec;

using Org.BouncyCastle.Math;

// using System.Text;
using System.Text.Json;

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto;

namespace ActiveledgerECC
{
  public class Signer
  {
    private ECPrivateKeyParameters privateKey;

    public Signer(String privateKey)
    {
      this.privateKey = getPrivateKeyFromString(privateKey);
    }

    public string Sign(String data)
    {
      String formattedData;
      formattedData = encodeJson(data);
      byte[] message = System.Text.Encoding.UTF8.GetBytes(formattedData);

      ISigner signer = SignerUtilities.GetSigner("SHA256withECDSA");
      signer.Init(true, this.privateKey);

      signer.BlockUpdate(message, 0, message.Length);
      byte[] signature = signer.GenerateSignature();

      String compressedSignature;
      compressedSignature = Convert.ToBase64String(signature);

      return compressedSignature;
    }

    // Not implmented
    private bool Verify(string data, string signature)
    {
      return false;
    }

    private ECPrivateKeyParameters getPrivateKeyFromString(String privateKey)
    {
      ECDomainParameters domainParams;
      domainParams = new ECDomainParameters(
          SecNamedCurves.GetByName("secp256k1")
      );

      String privateKeyClean = privateKey.Substring(2);

      ECPrivateKeyParameters privateKeyParams;
      privateKeyParams = new ECPrivateKeyParameters(
          new BigInteger(privateKeyClean, 16),
          domainParams
      );

      return privateKeyParams;
    }

    private String encodeJson(String data)
    {
      try
      {
        JsonDocument json = JsonDocument.Parse(data);
        String encoded = JsonSerializer.Serialize(json);
        return encoded;
      }
      catch (JsonException e)
      {
        throw new JsonException("Invalid JSON data", e);
      }
    }
  }
}
