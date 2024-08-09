<img src="https://www.activeledger.io/wp-content/uploads/2018/09/Asset-23.png" alt="Activeledger" width="500"/>

# Activeledger - C# ECC SDK
The Activeledger C# ECC SDK has been built to provide an easy way to generate an ECC keypair that can be used to sign transactions to be 
sent to the Activeledger network.

### Activeledger

[Visit Activeledger.io](https://activeledger.io/)

[Read Activeledgers documentation](https://github.com/activeledger/activeledger)

## Installation

```
```

## Usage

The SDK currently supports the following functions:
* Generate a new ECC keypair provided as HEX strings
* Sign a string using the generated private key

### Generate a new ECC keypair

The generate method returns an array containing the public and private keys as HEX strings.

```csharp
using ActiveledgerECC;

namespace MyNamespace
{
    public class MyClass
    {
        private void MyMethod()
        {
            KeyGenerator keyGen;
            keyGen = new KeyGenerator();
            
            String prv, pub;
            prv = keyGen.GetPrivateKey();
            pub = keyGen.GetPublicKey();
            
            Console.WriteLine("Private key HEX: " + prv + "\n");
            Console.WriteLine("Public key HEX: " + pub + "\n");
        }
    }
}
```

### Sign a string using a private key

The Signer class takes the private key as a HEX string and provides a method to sign a string.

The sign method takes the data to be signed **This must be a valid JSON string** and returns the signature base64 encoded.

**Note:** The data must be JSON.

```csharp
using ActiveledgerECC;

namespace MyNamespace
{
    public class MyClass
    {
        private void MyMethod(String privateKeyHex)
        {
            Signer signer;
            signer = new Signer(privateKeyHex);
            
            String signature;
            signature = signer.Sign(data);
            
            Console.WriteLine("Signature: " + signature + "\n");
        }
    }    
}
```

## License

---

This project is licensed under the [MIT](https://github.com/activeledger/activeledger/blob/master/LICENSE) License

