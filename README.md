# criptografia_openssl.desktop

```
[Desktop Entry]
Version=1.0
Type=Application
Name=Criptografia OpenSSL
Comment=Criptografia e Descriptografia usando OpenSSL e .NET 10
# O -ic força o bash a carregar seu .bashrc/.zshrc e injetar todas as variáveis que o .NET precisa antes de dar o cd
Exec=bash -ic "cd /mnt/disco_d/projetos/csharp/csharp_criptografia/publish && ./criptografia_csharp"
Icon=/mnt/disco_d/projetos/csharp/csharp_criptografia/criptografia_csharp/assets/cadeado.ico
Terminal=false
Categories=Utility;Security;
Path=/mnt/disco_d/projetos/csharp/csharp_criptografia/publish
```

# Urls

- [https://learn.microsoft.com/pt-br/dotnet/standard/security/walkthrough-creating-a-cryptographic-application](https://learn.microsoft.com/pt-br/dotnet/standard/security/walkthrough-creating-a-cryptographic-application)
- [https://learn.microsoft.com/pt-br/dotnet/standard/security/encrypting-data](https://learn.microsoft.com/pt-br/dotnet/standard/security/encrypting-data)
- [https://learn.microsoft.com/pt-br/dotnet/standard/security/decrypting-data](https://learn.microsoft.com/pt-br/dotnet/standard/security/decrypting-data)
- [Producing an AES Cipher To Match OpenSSL in C#](https://medium.com/asecuritysite-when-bob-met-alice/producing-an-aes-cipher-to-match-openssl-in-c-94209ba9615b)