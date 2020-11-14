# File Hash

ファイルのハッシュ値を取得する。


## スニペット

### MD5

```csharp
// input = filePath

string result = null;
using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
{
    var md5 = System.Security.Cryptography.MD5.Create();
    var md5Hash = md5.ComputeHash(fs);
    result = System.BitConverter.ToString(md5Hash);
}
```

### SHA1

```csharp
// input = filePath

string result = null;
using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
{
    var sha1 = System.Security.Cryptography.SHA1.Create();
    var sha1Hash = sha1.ComputeHash(fs);
    result = System.BitConverter.ToString(sha1Hash);
}
```

### SHA256

```csharp
// input = filePath

string result = null;
using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
{
    var sha256 = System.Security.Cryptography.SHA256.Create();
    var sha256Hash = sha256.ComputeHash(fs);
    result = System.BitConverter.ToString(sha256Hash);
}
```

## 備考

読み取り書き込みロックがかかっているファイルでも読み込めるよう `System.IO.FileShare.ReadWrite` を利用した。

