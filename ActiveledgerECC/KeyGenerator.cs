using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.EC;

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Asn1.Sec;

using Org.BouncyCastle.Security;

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
      ECKeyGenerationParameters keyGenParam = new ECKeyGenerationParameters(ecParams, new SecureRandom());

      ECKeyPairGenerator keyPairGenerator = new ECKeyPairGenerator("ECDSA");
      keyPairGenerator.Init(keyGenParam);

      AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();

      ECPrivateKeyParameters privateKeyParams = (ECPrivateKeyParameters)keyPair.Private;
      ECPublicKeyParameters publicKeyParams = (ECPublicKeyParameters)keyPair.Public;

      this.privateKey = "0x" + privateKeyParams.D.ToString(16);

      var publicKeyPoint = publicKeyParams.Q;
      this.publicKey = "0x" +
        (publicKeyPoint.YCoord.ToBigInteger().TestBit(0) ? "03" : "02") +
        publicKeyPoint.XCoord.ToBigInteger().ToString(16);
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
