using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.EC;

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Asn1.Sec;

using Org.BouncyCastle.Security;

using Org.BouncyCastle.Math.EC;

namespace ActiveledgerECC
{
  public class KeyGenerator
  {
    private string privateKey = string.Empty;
    private string publicKey = string.Empty;

    public void GenerateKeyPair()
    {

      // Setup key parameters
      DerObjectIdentifier oid = SecObjectIdentifiers.SecP256k1;
      X9ECParameters ecPs = CustomNamedCurves.GetByOid(oid);

      ECDomainParameters ecParams = new ECDomainParameters(
          ecPs.Curve,
          ecPs.G,
          ecPs.N,
          ecPs.H,
          ecPs.GetSeed()
      );
      ECKeyGenerationParameters keyGenParam;
      keyGenParam = new ECKeyGenerationParameters(
          ecParams,
          new SecureRandom()
          );

      // Generate keys
      ECKeyPairGenerator keyPairGenerator;
      keyPairGenerator = new ECKeyPairGenerator("ECDSA");

      keyPairGenerator.Init(keyGenParam);

      AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();

      ECPrivateKeyParameters privateKeyParams;
      privateKeyParams = (ECPrivateKeyParameters)keyPair.Private;
      ECPublicKeyParameters publicKeyParams;
      publicKeyParams = (ECPublicKeyParameters)keyPair.Public;

      // Convert keys to hex
      byte[] dBytes = privateKeyParams.D.ToByteArray();
      this.privateKey = "0x" + Convert.ToHexString(dBytes);

      ECPoint publicKeyPoint = publicKeyParams.Q.Normalize();
      byte[] compressed = publicKeyPoint.GetEncoded(true);
      this.publicKey = "0x" + Convert.ToHexString(compressed);
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
