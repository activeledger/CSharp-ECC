<img src="https://www.activeledger.io/wp-content/uploads/2018/09/Asset-23.png" alt="Activeledger" width="500"/>

# Activeledger - C# ECC SDK

> ## ⚠️ Unmaintained and archived — use [SDK-CSharp](https://github.com/activeledger/SDK-CSharp) instead
>
> This repository existed because the main C# SDK could not do secp256k1.
> **It can now**, and its implementation is materially better than this one.
>
> Do not copy the signing code here. It predates two things the ledger's
> ecosystem depends on:
>
> - **It does not normalise S to the lower half of the curve order.** Roughly
>   half of its signatures are therefore high-S. The ledger accepts those, but
>   `@noble/curves` — the reference for the JavaScript side — rejects them by
>   default, as do libsecp256k1 and Rust's `k256`. A signer emitting high-S
>   fails against such a verifier about half the time, which reads as flaky
>   auth rather than as a signature problem.
> - **It is not RFC 6979 deterministic**, so its output cannot be compared
>   against the published cross-language test vectors.
>
> [SDK-CSharp](https://github.com/activeledger/SDK-CSharp) does both, is checked against
> published reference bytes on every test run, and covers post-quantum
> identities as well.


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

